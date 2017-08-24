using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace wpfRoute
{
    class SQLiteControl
    {
        public String cs = "Data Source=C:\\Users\\klboy\\GitHub\\wpfRoute\\wpfRoute\\AppData\\Route.db;";

        // QUERY STATISTICS
        public int RecordCount;
        public DataTable DT;

        // EXECUTE QUERY SUB
        public void ExecQuery(String Query)
        {
            // RESET QUERY STATS
            RecordCount = 0;
        
            try
            {

                // CREATE DB COMMAND
                SQLiteConnection conn = new SQLiteConnection(cs);
                SQLiteCommand Cmd = new SQLiteCommand(Query, conn);
                SQLiteDataAdapter DA = new SQLiteDataAdapter(Cmd);
                DT = new DataTable();

                // EXECUTE COMMAND & FILL DATASET
                RecordCount = DA.Fill(DT);
                DA.Update(DT);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
        }
        // EXECUTE NON QUERY SUB
        public void ExecNonQuery(String Query)
        {
            SQLiteConnection conn = new SQLiteConnection(cs);
            try
            {
                conn.Open();
                SQLiteCommand Cmd = new SQLiteCommand(Query, conn);
                Cmd.ExecuteNonQuery();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}    