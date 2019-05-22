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
        ///<param name="VGActive">Tracks the time that a video game has been open.</param>
        private Stopwatch VGActive;
        ///<param name="played">The amount of time played currently stored for the day on the database.</param>
        private TimeSpan played;
        ///<param name="maxPlay">The maxPlay time currently stored for the day on the database.</param>
        private TimeSpan maxPlay;
        ///<param name="dayEnd">The end of today to compare with for writing to the database at the end of the day.</param>
        private DateTime dayEnd;
        ///<param name="vd">The ViewData screen instance to view data in.</param>
        private ViewData vd;
        ///<param name="treatmentStart">The date to start the treatment phase.</param>
        private DateTime treatmentStart;
        ///<param name="oneAM">For comparison for daily reset and creation of new database entry.</param>
        private DateTime oneAM;

        /// <summary>
        /// Initialize the program: Start the check time and create a new entry for today if one hasn't been created.
        /// </summary>
        public TimerScreen()
        {
            InitializeComponent();

            treatmentStart = new DateTime(2019, 5, 26); //May 26, 2019
            oneAM = new DateTime(2019,5,22,1,0,0); //1 AM

            CheckActive.Start(); //Start the activity checking timer
            SetForDay(); //setup for the day
        }

        /// <summary>
        /// Shows the current processes in a message box.
        /// </summary>
        private void GetProcesses()
        {
            StringBuilder sb = new StringBuilder();
            Process[] procs = Process.GetProcesses(); //get all current processes
            for(int i = 0; i < procs.Length; i++) //add any process not host or chrome to list
                if(!procs[i].ProcessName.Contains("host") && !procs[i].ProcessName.Contains("chrome") && !procs[i].ProcessName.Contains("Host"))
                    sb.Append(procs[i].ProcessName + " : ");
            MessageBox.Show(sb.ToString()); //show the processes minus chrome and host processes.
        }

        /// <summary>
        /// Set the day end time to record data if the program isn't turned off (it will save if shutoff)
        /// </summary>
        private void SetForDay()
        {
            DateTime now = DateTime.Today; //get today's datetime
            dayEnd = new DateTime(now.Day, now.Month, now.Day, 23, 58, 0); //11:58 pm today
            DataTable todayData = SQLconn.NewDay(); //create a new entry for today if not yet created and get the values for today
            if (todayData == null) //make sure something was returned
            {
                MessageBox.Show("Database Error", "Could not load database data for today.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            VGActive = new Stopwatch(); //create a new stopwatch for the daily session
            played = (TimeSpan)todayData.Rows[0]["played"]; //retrieve the played time for the day
            maxPlay = (TimeSpan)todayData.Rows[0]["maxPlay"]; //retrieve the maxPlay time for the day
            MaxPlaylbl.Text = maxPlay.ToString(); //set the text of the max play label.
            UpdateTime(null, null); //set the time active and time left labels
            if (vd != null) //update the data view if it has been created
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

        /// <summary>
        /// Checks if any of the game processe in the list are in the current list of running processes.
        /// </summary>
        /// <returns>True if any of the processes are running, false if none are found.</returns>
        private bool GamesRunning()
        {
            ///<param name="games">The list of process names to search for</param>
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
        /// <param name="sender">CheckActive</param>
        /// <param name="e">Tick</param>
        private void CheckRunning(object sender, EventArgs e)
        {
            //Record played time to database if it is the end of the day
            if (DateTime.Now > dayEnd)
                SQLconn.SetVGtime(played + VGActive.Elapsed);

            //
            else if (DateTime.Now.Hour == oneAM.Hour)
                SetForDay();

            if (GamesRunning())
            {
                VGActive.Start();
                VGUpdate.Start();
                if ((VGActive.Elapsed + played) >= maxPlay && DateTime.Now > treatmentStart)
                {
                    //activate after baseline data collected
                    string dir = System.AppContext.BaseDirectory + "sound.wav";
                    System.Media.SoundPlayer alarm = new System.Media.SoundPlayer(dir);
                    alarm.Play();
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
