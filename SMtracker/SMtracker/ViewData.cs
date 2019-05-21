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
                foreach(DataGridViewColumn col in DataView.Columns)
                {
                    if(col.Index == DataView.Columns.Count - 1)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        int width = col.Width;
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        col.Width = width;
                    }
                }
            }
        }

        private void UpdateDV(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
