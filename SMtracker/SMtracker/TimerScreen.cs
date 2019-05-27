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
        /// <param name="saved">Bit for tracking whether data has been saved to the database or not.</param>
        private bool saved = true;
        private DataTable games;

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
            games = SQLconn.GetTracked();
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
            if (!saved)
            {
                SQLconn.SetVGtime(played + VGActive.Elapsed);
                saved = true;
            }
            
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

            saved = false;
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
            //string[] games = {"Wow", "Diablo III64", "Hearthstone", "SC2_x64" , "destiny2", "Steam", "Solitaire", "swtor" };
            

            for(int i = 0; i < games.Rows.Count; i++)
            {
                Process[] pname = Process.GetProcessesByName(games.Rows[i][0].ToString());
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
            if (!saved && DateTime.Now > dayEnd)
            {
                SQLconn.SetVGtime(played + VGActive.Elapsed);
                saved = true;
            }
            //Create a new entry for the new day at 1 AM if running
            if (DateTime.Now.Hour == oneAM.Hour)
                SetForDay();

            //Check if games are running, if so then start the timers.
            if (GamesRunning())
            {
                VGActive.Start();
                VGUpdate.Start();
                //If in treatment phase, when the played time exceeds the maxPlay time: SOUND THE ALARM!!!
                if ((VGActive.Elapsed + played) >= maxPlay && DateTime.Now > treatmentStart)
                {
                    string dir = System.AppContext.BaseDirectory + "sound.wav";
                    System.Media.SoundPlayer alarm = new System.Media.SoundPlayer(dir);
                    alarm.Play();
                }
                saved = false;
            }
            //If games are not running, deactivate the timers
            else
            {
                VGActive.Stop();
                VGUpdate.Stop();
            }
        }

        /// <summary>
        /// Update the time displays for played and play remaining each second.
        /// </summary>
        /// <param name="sender">VGUpdate</param>
        /// <param name="e">Tick</param>
        private void UpdateTime(object sender, EventArgs e)
        {
            TimeSpan ts = played + VGActive.Elapsed;
            TimeActive.Text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

            ts = maxPlay - ts;
            TimeLeftLbl.Text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }

        /// <summary>
        /// Save the time played if the program is closing. However, if games are running, do not allow the program to close.
        /// </summary>
        /// <param name="sender">Application</param>
        /// <param name="e">Closing</param>
        private void Save(object sender, FormClosingEventArgs e)
        {
            if (GamesRunning())
                e.Cancel = true; //cancel close
            else if(!saved)
                SQLconn.SetVGtime(played + VGActive.Elapsed);
        }

        /// <summary>
        /// Adds the time (in minutes) indicated in the spinner to the exercise time.
        /// </summary>
        /// <param name="sender">Exercise Add button</param>
        /// <param name="e">Click</param>
        private void ExerciseBtn_Click(object sender, EventArgs e)
        {
            //Get the exercise type
            string type;
            if (walkRBtn.Checked)
                type = "walk";
            else if (yardworkRbtn.Checked)
                type = "yardwork";
            else if (bikeRBtn.Checked)
                type = "bike";
            else if (workoutRBtn.Checked)
                type = "workout";
            else
            {
                MessageBox.Show("No exercise type selected", "An exercise type must be selected.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SQLconn.AddExerciseTime(TimeSpan.FromMinutes((double)ExHours.Value*60+(double)ExMins.Value), type))
            {
                SetForDay(); //update displays
                ExMins.Value = 0; //reset minutes counter to 0
                ExHours.Value = 0; //reset hour counter to 0
            }
            else
                MessageBox.Show("An error occured which prevented the exercise from being added.\nPlease check connection to the database " + type, 
                    "Exercise not added", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Opens the View Data window.
        /// </summary>
        /// <param name="sender">View Data button</param>
        /// <param name="e">Click</param>
        private void ViewData(object sender, EventArgs e)
        {
            //if not created, create an instance of the View Data window
            if(vd == null)
            {
                vd = new ViewData();
            }
            vd.Show();
        }

        /// <summary>
        /// Exit the program when Alt-F4 or exit button in the file menu is pressed.  Save before exiting if needed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, EventArgs e)
        {
            if (!saved)
                SQLconn.SetVGtime(played + VGActive.Elapsed);
            if (!GamesRunning())
                Application.Exit();
        }

        /// <summary>
        /// Load options screen on shortcut F10 or click File>Options.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowOptions(object sender, EventArgs e)
        {
            OptionWindow ops = new OptionWindow();
            ops.ShowDialog();
            games = SQLconn.GetTracked();
        }
    }
}
