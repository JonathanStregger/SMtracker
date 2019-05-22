using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMtracker
{
    public partial class ViewData : Form
    {
        public ViewData()
        {
            InitializeComponent();
        }

        private void HideForm(object sender, FormClosingEventArgs e)
        {
            if (ContainsFocus)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void UpdateView()
        {
            if (!Visible)
                return;
            DataTable dt = SQLconn.GetDB();
            if(dt != null)
            {
                BindingSource dbBind = new BindingSource { DataSource = dt };
                DataView.DataSource = dbBind;

                DataView.Columns[0].HeaderText = "Date";
                DataView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataView.Columns[1].HeaderText = "VG Played";
                DataView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataView.Columns[2].HeaderText = "Available Play";
                DataView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataView.Columns[3].HeaderText = "Time Exercised";
                DataView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void UpdateDV(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
