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

            DataView.DataSource = SQLconn.GetVGRecords();

            foreach (DataGridViewRow row in DataView.Rows)
            {
                //Get day of the week
                DateTime day = (DateTime)row.Cells[1].Value;
                row.Cells[0].Value = day.DayOfWeek;

                //Truncate milliseconds in VG played and Available Play
                TimeSpan time = (TimeSpan)row.Cells[2].Value;
                row.Cells[2].Value = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
                time = (TimeSpan)row.Cells[3].Value;
                row.Cells[3].Value = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
            }
            return;
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

        private void ViewData_Load(object sender, EventArgs e)
        {
            UpdateView();
        }

        /// <summary>
        /// Hides the window when escape is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckHide(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Hide();
        }
    }
}
