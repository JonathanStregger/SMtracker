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

        /// <summary>
        /// Hides the form instead of disposing when the red X is clicked.
        /// </summary>
        /// <param name="sender">Red X button</param>
        /// <param name="e">Closing</param>
        private void HideForm(object sender, FormClosingEventArgs e)
        {
            //Only cancel the close if the View Data window is focused.  Otherwise, this window should close.
            if (ContainsFocus)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /// <summary>
        /// Updates the data in the Data View from the database.
        /// </summary>
        public void UpdateView()
        {
            //Only update when visible
            if (!Visible)
                return;
            //Get the data from the database and put it in the grid view
            DataTable dt = SQLconn.GetDB();
            if(dt != null)
            {
                BindingSource dbBind = new BindingSource { DataSource = dt };
                DataView.DataSource = dbBind;

                //Set the column headers and size modes
                DataView.Columns[0].HeaderText = "Date";
                DataView.Columns[1].HeaderText = "VG Played";
                DataView.Columns[2].HeaderText = "Available Play";
                DataView.Columns[3].HeaderText = "Exercised";
                DataView.Columns[4].HeaderText = "Walk";
                DataView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                DataView.Columns[4].Width = 70;
                DataView.Columns[5].HeaderText = "Workout";
                DataView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                DataView.Columns[5].Width = 70;
                DataView.Columns[6].HeaderText = "Bike";
                DataView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                DataView.Columns[6].Width = 70;
                DataView.Columns[7].HeaderText = "Yardwork";
                DataView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DataView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                
                //Create a column for the day of the week
                DataView.Columns.Add("DotW", "DotW");
                DataView.Columns[8].DisplayIndex = 0;

                foreach (DataGridViewRow row in DataView.Rows)
                {
                    //Get day of the week
                    DateTime day = (DateTime)row.Cells[0].Value;
                    row.Cells[8].Value = day.DayOfWeek;
                
                    //Truncate milliseconds in VG played and Available Play
                    TimeSpan time = (TimeSpan)row.Cells[1].Value;
                    row.Cells[1].Value = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
                    time = (TimeSpan)row.Cells[2].Value;
                    row.Cells[2].Value = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
                }
            }
            else
                MessageBox.Show("An error occured which prevented the data from being retrieved.\nPlease check connection to the database",
                    "Data not accessible", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Update the view whenever the visibility of the window is changed to visible.
        /// </summary>
        /// <param name="sender">Form</param>
        /// <param name="e">Visibility Changed</param>
        private void UpdateDV(object sender, EventArgs e)
        {
            if(Visible)
                UpdateView();
        }
    }
}
