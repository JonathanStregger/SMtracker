using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMtracker
{
    public partial class OptionWindow : Form
    {
        public OptionWindow()
        {
            InitializeComponent();
        }
        private void UpdateTables()
        {
            DataTable VGs = SQLconn.GetVGs();
            if (VGs != null)
            {
                BindingSource VGsBind = new BindingSource { DataSource = VGs };
                VG2Track.DataSource = VGsBind;
                VG2Track.Columns[1].HeaderText = "Name";
                VG2Track.Columns[1].DisplayIndex = 0;
                VG2Track.Columns[0].HeaderText = "Process";
                VG2Track.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }

            Process[] procs = Process.GetProcesses(); //get all current processes
            DataTable dtProcs = new DataTable();
            dtProcs.Columns.Add("Running Processes");
            DataRow row;
            for (int i = 0; i < procs.Length; i++)
            {
                row = dtProcs.NewRow();
                row["Running Processes"] = procs[i].ProcessName;
                dtProcs.Rows.Add(row);
            }
            BindingSource procsBind = new BindingSource { DataSource = dtProcs };
            Processes.DataSource = procsBind;
        }

        private void LoadVGs(object sender, EventArgs e)
        {
            UpdateTables();
        }

        private void TrackNewVG(object sender, EventArgs e)
        {
            if(VGName.Text.Length > 50 || VGName.Text.Length < 1)
            {
                MessageBox.Show("Invalid VG name", "Invalid VG name",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Processes.SelectedRows.Count == 1)
            {
                if (SQLconn.AddTracker(VGName.Text, (string)Processes.SelectedRows[0].Cells[0].Value))
                    MessageBox.Show("Process successfully added", "Process for " + VGName.Text + " was added.",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Process could not be added.  Check connection to database.", "Process failed to add", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("A process must be selected.", "No process selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            UpdateTables();
        }

        private void Serach(object sender, EventArgs e)
        {
            CurrencyManager man = (CurrencyManager)BindingContext[Processes.DataSource];
            man.SuspendBinding();
            Processes.ClearSelection();
            foreach(DataGridViewRow row in Processes.Rows)
            {
                row.Visible = true;
                if (!((string)row.Cells[0].Value).ToLower().Contains(SearchBar.Text.ToLower()))
                {
                    row.Visible = false;
                }
            }
            man.ResumeBinding();
        }
    }
}
