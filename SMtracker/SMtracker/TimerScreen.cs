using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SMtracker
{
    public partial class TimerScreen : Form
    {
        private Stopwatch VGActive = new Stopwatch();
        private TimeSpan played;
        private TimeSpan maxPlay;
        private DateTime dayEnd;
        private ViewData vd;

        /// <summary>
        /// Initialize the program: Start the check time and create a new entry for today if it
        /// </summary>
        public TimerScreen()
        {
            InitializeComponent();
            CheckActive.Start();
            SetForDay();
            StringBuilder sb = new StringBuilder();
            /*Process[] procs = Process.GetProcesses();
            for(int i = 0; i < procs.Length; i++)
                if(!procs[i].ProcessName.Contains("host") && !procs[i].ProcessName.Contains("chrome") && !procs[i].ProcessName.Contains("Host"))
                    sb.Append(procs[i].ProcessName + " : ");
            MessageBox.Show(sb.ToString());*/
        }

        /// <summary>
        /// Set the day end time to record data if the program isn't turned off (it will save if shutoff)
        /// </summary>
        private void SetForDay()
        {
            DateTime now = DateTime.Today;
            dayEnd = new DateTime(now.Day, now.Month, now.Day, 23, 0, 0); //11 pm
            DataTable todayData = SQLconn.NewDay();
            played = (TimeSpan)todayData.Rows[0]["played"];
            maxPlay = (TimeSpan)todayData.Rows[0]["maxPlay"];
            MaxPlaylbl.Text = maxPlay.ToString();
            UpdateTime(null, null);
            if (vd != null)
                vd.UpdateView();
        }

        /// <summary>
        /// Raises a dialog for exit when exit button is pressed. If the yes button is pressed, the application exits.
        /// </summary>
        /// <param name="sender">Exit button</param>
        /// <param name="e">Click</param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit SM Tracker?", "Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                SQLconn.SetVGtime(played + VGActive.Elapsed);
                Application.Exit();
            }
        }

        private bool GamesRunning()
        {
            string[] games = {"Wow", "Diablo III64", "Hearthstone", "SC2_x64" , "destiny2", "Steam", "Solitaire", "swtor" };
            for(int i = 0; i < games.Length; i++)
            {
                Process[] pname = Process.GetProcessesByName(games[i]);
                if (pname.Length != 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if any video games are running.  Starts active timer if any are active.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckRunning(object sender, EventArgs e)
        {
            //record played time if it is 
            if (DateTime.Now > dayEnd)
                SQLconn.SetVGtime(played + VGActive.Elapsed);
            else if (DateTime.Today.Day != dayEnd.Day)
                SetForDay();
            if (GamesRunning())
            {
                VGActive.Start();
                VGUpdate.Start();
                if ((VGActive.Elapsed + played) >= maxPlay)
                {
                    //activate after baseline data collected
                    /*string dir = System.AppContext.BaseDirectory + "sound.wav";
                    System.Media.SoundPlayer alarm = new System.Media.SoundPlayer(dir);
                    alarm.Play();*/
                }
            }
            else
            {
                VGActive.Stop();
                VGUpdate.Stop();
            }
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            TimeSpan ts = played + VGActive.Elapsed;
            TimeActive.Text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            ts = maxPlay - ts;
            TimeLeftLbl.Text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        private void Save(object sender, FormClosingEventArgs e)
        {
            SQLconn.SetVGtime(played + VGActive.Elapsed);
            if (GamesRunning())
                e.Cancel = true;
        }

        private void ExerciseBtn_Click(object sender, EventArgs e)
        {
            SQLconn.AddExerciseTime(new TimeSpan(0, (int)ExerciseCounter.Value, 0));
            SetForDay();
            ExerciseCounter.Value = 0;
        }

        private void ViewData(object sender, EventArgs e)
        {
            if(vd == null)
            {
                vd = new ViewData();
            }
            vd.Show();
        }
    }
}
