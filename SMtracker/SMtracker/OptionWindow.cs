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
        /// <param name="host">The host timer screen which called this form.</param>"
        private TimerScreen host;
        public OptionWindow(TimerScreen ts)
        {
            InitializeComponent();
            host = ts;
        }

        /// <summary>
        /// Updates the display of actively tracked processes and the display of active processes.
        /// </summary>
        private void UpdateTables()
        {
            //Get all the tracked processes from the database
            DataTable VGs = SQLconn.GetVGs();
            if (VGs != null)
            {
                BindingSource VGsBind = new BindingSource { DataSource = VGs };
                VG2Track.DataSource = VGsBind; //set the data for the display
                //Set the column header text, switch the order of the two columns and set the process column to fill
                VG2Track.Columns[1].HeaderText = "Name";
                VG2Track.Columns[1].DisplayIndex = 0;
                VG2Track.Columns[0].HeaderText = "Process";
                VG2Track.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            Process[] procs = Process.GetProcesses(); //get all current processes
            DataTable dtProcs = new DataTable();
            dtProcs.Columns.Add("Running Processes");
            DataRow row;
            //Add all of the currently running processes from the list to the datatable.
            for (int i = 0; i < procs.Length; i++)
            {
                row = dtProcs.NewRow();
                row["Running Processes"] = procs[i].ProcessName;
                dtProcs.Rows.Add(row);
            }
            BindingSource procsBind = new BindingSource { DataSource = dtProcs };
            Processes.DataSource = procsBind; //Set the process view to the data
        }

        /// <summary>
        /// Load data into the displayed tables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadVGs(object sender, EventArgs e)
        {
            UpdateTables();
        }

        /// <summary>
        /// Add a new process to the tracked processes list in the database
        /// </summary>
        /// <param name="sender">Track button</param>
        /// <param name="e">Click</param>
        private void TrackNewVG(object sender, EventArgs e)
        {
            //Check that the given display name to associate with the process is between 1 and 50 characters
            if(VGName.Text.Length > 50 || VGName.Text.Length < 1)
            {
                MessageBox.Show("Invalid display name", "Invalid display name",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //If there is a process selected, add it to the database with the given display name.
            if (Processes.SelectedRows.Count == 1)
            {
                //Attempt to add the process to be tracked.
                if (SQLconn.AddTracker(VGName.Text, (string)Processes.SelectedRows[0].Cells[0].Value))
                {
                    MessageBox.Show("Process successfully added", "Process for " + VGName.Text + " was added.",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    host.SetTracked(); //reset the tracked list to be checked by the timer.
                }
                else
                    MessageBox.Show("Process could not be added.  Check connection to database.", "Process failed to add", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("A process must be selected.", "No process selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            UpdateTables(); //Update the displayed tables
        }

        /// <summary>
        /// Filter the displayed processes by the text entered in the searchbar.
        /// </summary>
        /// <param name="sender">SearchBar</param>
        /// <param name="e">TextChanged</param>
        private void Serach(object sender, EventArgs e)
        {
            //Disable the currency manager while visibility of rows is being altered.
            CurrencyManager man = (CurrencyManager)BindingContext[Processes.DataSource];
            man.SuspendBinding();
            Processes.ClearSelection();
            
            //Make all the rows that contain the contents of the search bar visible and all others not visible.
            foreach(DataGridViewRow row in Processes.Rows)
            {
                row.Visible = true;
                if (!((string)row.Cells[0].Value).ToLower().Contains(SearchBar.Text.ToLower()))
                    row.Visible = false;
            }
            man.ResumeBinding(); //resume managing binding.
        }

        /// <summary>
        /// Delete the selected process.
        /// </summary>
        /// <param name="sender">Delete Button</param>
        /// <param name="e">Click</param>
        private void DeleteTracker(object sender, EventArgs e)
        {
            if (VG2Track.SelectedRows.Count != 1)
                return;

            string process = (string)VG2Track.SelectedRows[0].Cells[0].Value; //get the process that is selected
            if(MessageBox.Show(string.Format("Delete tracker for {0}?", (string)VG2Track.SelectedRows[0].Cells[1].Value),
                "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SQLconn.RemoveTracker(process))
                    MessageBox.Show(process + " will no longer be tracked.", "Process tracker removed");
                else
                    MessageBox.Show(process + " could not be untracked.  Please check connection to the database.",
                        "Process still tracked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Submit edited cell data.
        /// </summary>
        /// <param name="sender">VG2Track</param>
        /// <param name="e">End edit cell</param>
        private void SubmitEdit(object sender, DataGridViewCellEventArgs e)
        {
            //only save for edits on display name column
            if (e.ColumnIndex == 1)
                return;

            string newDisplay = (string)VG2Track.Rows[e.RowIndex].Cells[0].Value;
            string processName = (string)VG2Track.Rows[e.RowIndex].Cells[1].Value;
            //check length of new display name for range
            if (newDisplay.Length > 0 && newDisplay.Length < 51)
            {
                if (SQLconn.EditTracker(newDisplay, processName))
                    MessageBox.Show(processName + " updated with new display name: " + newDisplay,
                        "Update Success");
                else
                    MessageBox.Show(processName + " could not be updated with new display name: " + newDisplay + 
                        " Please check conneciton the the database.", "Update Failure", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Invalid display name detected.", "Invalid Text Entered", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            UpdateTables(); //update tables to either show changes or revert depending on entry validity.
        }

        /// <summary>
        /// Only allow edit of display name column.
        /// </summary>
        /// <param name="sender">VG2Track</param>
        /// <param name="e">Enter edit cell</param>
        private void EditTracked(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
                e.Cancel = true;
        }
    }
}
