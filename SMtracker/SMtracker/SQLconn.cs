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
        private static readonly string ConnString = "Data Source = JON-PC; Initial Catalog = SMtracker; Integrated Security=SSPI";//User ID=Tracker;Password=PSYCSpring2019";
        private static SqlConnection Connection = new SqlConnection(ConnString);
        private static string[] ExTypes = { "walk", "yardwork", "workout", "bike" };

        /// <summary>
        /// Creates a new entry in the database for today if not already started.
        /// </summary>
        /// <returns>The current value of played.</returns>
        public static DataTable NewDay()
        {
            DataTable dt = QueryDatabase("SELECT * FROM VGRecord WHERE VGDate = '" + DateTime.Today.ToString() + "'");
            if(dt != null && dt.Rows.Count == 0)
            {
                //Insert an entry for today into
                NonQuery("INSERT INTO VGRecord (VGDate) VALUES ('" + DateTime.Today.ToString() + "')");
                dt = QueryDatabase("SELECT * FROM VGRecord WHERE VGDate = '" + DateTime.Today.ToString() + "'");
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

            //Get the new maxPlay and exerciseTotal
            TimeSpan maxPlay = exercised + (TimeSpan)dt.Rows[0]["maxPlay"];
            TimeSpan exTotal = exercised + (TimeSpan)dt.Rows[0]["exerciseTotal"];
            exercised += (TimeSpan)dt.Rows[0][type];

            string cmd = string.Format("UPDATE VGRecord SET maxPlay = '{0}', {1} = '{2}', exerciseTotal = '{3}' WHERE VGDate = '{4}'",
                maxPlay.ToString(), type, exercised.ToString(), exTotal.ToString(), DateTime.Today.ToString());
            return NonQuery(cmd.ToString());
        }

        /// <summary>
        /// Set the VGTime for today.
        /// </summary>
        /// <param name="played">The time played</param>
        /// <returns>True if successful, false if not successful.</returns>
        public static bool SetVGtime(TimeSpan played)
        {
            DateTime today = DateTime.Today;
            if (NonQuery(string.Format("UPDATE VGRecord SET played = '{0}' WHERE VGDate = '{1}'", played.ToString(),
                today.ToString())))
            {
                DataTable rec = QueryDatabase(string.Format("SELECT played, exerciseTotal FROM VGRecord WHERE VGDate = '{0}'", 
                    today.ToString()));
                if(rec != null && rec.Rows.Count == 1)
                {
                    TimeSpan maxPlay;
                    if((TimeSpan)rec.Rows[0]["exerciseTotal"] > (TimeSpan)rec.Rows[0]["played"])
                        maxPlay = (TimeSpan)rec.Rows[0]["exerciseTotal"] - (TimeSpan)rec.Rows[0]["played"];
                    else
                        maxPlay = new TimeSpan(0);
                    return NonQuery(string.Format("UPDATE VGRecord SET maxPlay = '{0}' WHERE VGDate = '{1}'", maxPlay.ToString(), today.ToString()));
                }
                return false;
            }
            else
                return false;
        }

        public static DataTable GetDB()
        {
            return QueryDatabase("SELECT * FROM VGRecord");
        }

        public static DataTable GetVGs()
        {
            return QueryDatabase("SELECT * FROM VGs");
        }

        public static bool AddTracker(string VGname, string procName)
        {
            return NonQuery(string.Format("INSERT INTO VGs (programName, processName) VALUES ('{0}', '{1}')", VGname, procName));
        }

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
                
                Connection.Close();
                return false;
            }
            catch //(Exception ex)
            {
                Connection.Close();
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
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
                Connection.Close();
                return data;
            }
            catch
            {
                //If no data returned, return null
                Connection.Close();
                return null;
            }
        }
    }
}
