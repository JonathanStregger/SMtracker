using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMtracker
{
    static class SQLconn
    {
        // Connection string to the database
        private static readonly string ConnString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.AppContext.BaseDirectory + "SMData.mdf;Integrated Security=True";
        private static SqlConnection Connection = new SqlConnection(ConnString);
        private static string[] ExTypes = { "walk", "yardwork", "workout", "cardio" };

        /// <summary>
        /// Creates a new entry in the database for today if not already started.
        /// </summary>
        /// <param name="day">The day to get the data for</param>
        /// <returns>The current value of played.</returns>
        public static DataTable RecordByDate(DateTime day)
        {
            string dayDate = day.Date.ToShortDateString();
            DataTable dt = QueryDatabase("SELECT * FROM VGRecord WHERE VGDate = '" + dayDate + "'");
            if((dt == null || dt.Rows.Count == 0) && day.Date <= DateTime.Now.Date)
            {
                //get the leftover play time from yesterday
                DataTable yesterData = QueryDatabase("SELECT availablePlay FROM VGRecord WHERE VGDate = '" +
                    DateTime.Today.AddDays(-1).ToString() + "'");
                if (yesterData != null && yesterData.Rows.Count > 0)
                {
                    TimeSpan availablePlay = (TimeSpan)yesterData.Rows[0]["availablePlay"];
                    availablePlay = availablePlay.Add(TimeSpan.FromHours(1));
                    //Insert an entry for today
                    if (NonQuery(string.Format("INSERT INTO VGRecord (VGDate, availablePlay) VALUES ('{0}', '{1}')",
                            dayDate, availablePlay.ToString())))
                        dt = QueryDatabase("SELECT * FROM VGRecord WHERE VGDate = '" + dayDate + "'");

                }
                //Insert an entry for today without a specified availablePlay (default of 1 hour)
                else if (NonQuery(string.Format("INSERT INTO VGRecord (VGDate) VALUES ('{0}')", dayDate)))
                    dt = QueryDatabase("SELECT * FROM VGRecord WHERE VGDate = '" + dayDate + "'");
            }
            return dt;
        }

        /// <summary>
        /// Adds exercise time onto the days total, the type total and max play total.
        /// </summary>
        /// <param name="exercised"></param>
        /// <returns></returns>
        public static bool AddExerciseTime(TimeSpan exercised, string type)
        {
            //Check that the exercise time is positive and that the type is available, else return false
            if (exercised.TotalMinutes < 1 || !ExTypes.Any(s => type.Contains(s)))
                return false;

            //Get today's data
            DataTable dt = QueryDatabase("SELECT * FROM VGRecord WHERE VGDate = '" + DateTime.Today.ToString() + "'");
            if (dt == null) //if nothing returned, return false.
                return false;

            //Get the new availablePlay and exerciseTotal
            TimeSpan availablePlay = exercised + (TimeSpan)dt.Rows[0]["availablePlay"];
            TimeSpan exTotal = exercised + (TimeSpan)dt.Rows[0]["exerciseTotal"];
            exercised += (TimeSpan)dt.Rows[0][type];

            string cmd = string.Format("UPDATE VGRecord SET availablePlay = '{0}', {1} = '{2}', exerciseTotal = '{3}' WHERE VGDate = '{4}'",
                availablePlay.ToString(), type, exercised.ToString(), exTotal.ToString(), DateTime.Today.ToString());
            return NonQuery(cmd.ToString());
        }

        /// <summary>
        /// Set the VGTime for today.
        /// </summary>
        /// <param name="played">The time played</param>
        /// <param name="available">The time left to play</param>
        /// <returns>True if successful, false if not successful.</returns>
        public static bool SaveVGtime(TimeSpan played, TimeSpan available)
        {
            return NonQuery(string.Format("UPDATE VGRecord SET played = '{0}', availablePlay = '{1}' WHERE VGDate = '{2}'",
                played.ToString(), available.ToString(), DateTime.Today.ToString()));
        }

        /// <summary>
        /// Get the data from the VGRecords table for the time played, available, and exercise data.
        /// </summary>
        /// <returns>The VGRecords data</returns>
        public static DataTable GetVGRecords()
        {
            return QueryDatabase("SELECT * FROM VGRecord");
        }

        /// <summary>
        /// Gets the data from teh VGs table for the processes to track.
        /// </summary>
        /// <returns>Tracked process data</returns>
        public static DataTable GetVGs()
        {
            return QueryDatabase("SELECT * FROM VGs");
        }

        /// <summary>
        /// Add a process to track.
        /// </summary>
        /// <param name="VGname">Display name for the process.</param>
        /// <param name="procName">The process name</param>
        /// <returns>True if the process was added to the tracked list, false if it was not.</returns>
        public static bool AddTracker(string VGname, string procName)
        {
            return NonQuery(string.Format("INSERT INTO VGs (programName, processName) VALUES ('{0}', '{1}')", VGname, procName));
        }

        /// <summary>
        /// Gets the data on the tracked processes.
        /// </summary>
        /// <returns>Data on the tracked processes</returns>
        public static DataTable GetTracked()
        {
            return QueryDatabase("SELECT processName FROM VGs");
        }

        /// <summary>
        /// Sends the given non query to the database.
        /// </summary>
        /// <param name="cmd">The SQL non query for add, update, or delete.</param>
        /// <returns>True if non-query executed, false if not.</returns>
        private static bool NonQuery(string cmd)
        {
            //Throw an exception if the query contains multiple queries
            if (cmd.Count(sc => sc == ';') > 0)
                return false;

            //Send the query to the database and return true if successful, false if it was not
            try
            {
                SqlCommand query = new SqlCommand(cmd, Connection);
                Connection.Open();

                if (query.ExecuteNonQuery() == 1)
                {
                    Connection.Close();
                    return true;
                }
                
                return false;
            }
            catch //(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

        }

        /// <summary>
        /// Queries the database with the given command.
        /// </summary>
        /// <param name="query">The query for the database.</param>
        /// <returns>A datatable of the results.</returns>
        /// <exception cref="DataException">If the query does not meet restrainsts</exception>
        private static DataTable QueryDatabase(string query)
        {
            //Throw an exception if the query contains multiple queries
            if (query.Count(sc => sc == ';') > 0)
                throw new DataException("Invalid SQL statement.");

            //Send the query to the database and return true if successful, false if it was not
            Connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(query, Connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                da.Fill(data);
                da.Dispose();
                return data;
            }
            catch //(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                //If no data returned, return null
                return null;
            }
            finally
            {
                if(Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Remove the given process tracker entry from the VGs table.
        /// </summary>
        /// <param name="processName">The process to remove.</param>
        /// <returns>True if the process was removed, false if it was not.</returns>
        public static bool RemoveTracker(string processName)
        {
            return NonQuery("DELETE FROM VGs WHERE processName = '" + processName + "'");
        }

        /// <summary>
        /// Updates the display name for the given process name.
        /// </summary>
        /// <param name="displayName">The new display name for the process</param>
        /// <param name="processName">The process to update</param>
        /// <returns></returns>
        public static bool EditTracker(string displayName, string processName)
        {
            return NonQuery(string.Format("UPDATE VGs SET programName = '{0}' WHERE processName = '{1}'", 
                displayName, processName));
        }
    }
}
