using System.Data.SqlClient;

namespace Measurement.Services
{
    public static class MeasurementService
    {
        public static List<Models.Measurement> GetMeasurementParameters(string connectionString)
        {
            List<Models.Measurement> measurementList = new List<Models.Measurement>();
            SqlConnection con = new SqlConnection(connectionString);

            //ExecuteSQLCommands(con);
            ShowConnectionStatus(con);

            string sqlQuery = "select MeasurementId, MeasurementName, Unit from Measurement"; // where MeasurementID = 1";
            con.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Measurement.Models.Measurement measurementParameter = new Measurement.Models.Measurement();

                    measurementParameter.MeasurementId = Convert.ToInt32(dr["MeasurementId"]);
                    measurementParameter.MeasurementName = dr["MeasurementName"].ToString();
                    measurementParameter.MeasurementUnit = dr["Unit"].ToString();

                    measurementList.Add(measurementParameter);
                }
            }
           ShowConnectionStatus(con);
           con.Close();
           return measurementList;
        }



        public static List<Models.Measurement> RemoveMeasurementParameter(string connectionString)
        {
            List<Models.Measurement> measurementList = new List<Models.Measurement>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                ExecuteSQLCommands(con);
                ShowConnectionStatus(con);

                string sqlQuery = "DELETE FROM Measurement where [MeasurementName] like 'radiation%'";
                con.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteScalar();

                //con.Close();
                ShowConnectionStatus(con);

            }

            measurementList = GetMeasurementParameters(connectionString);
            return measurementList;
        }

        public static List<Models.Measurement> UpdateElementFromDB(string connectionString)
        {
            List<Models.Measurement> measurementList = new List<Models.Measurement>();

            //string connectionString = "Data Source=LTVALIASHVILINB;Initial Catalog=Measurement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                ExecuteSQLCommands(con);
                ShowConnectionStatus(con);

                string sqlQuery = "UPDATE Measurement set MeasurementName ='radiation' where Unit like 'W%' ";
                con.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteScalar();

                measurementList = GetMeasurementParameters(connectionString);

                // con.Close();
            }
            return measurementList;
        }


        private static void ShowConnectionStatus(SqlConnection connection)
        {
            // Show various info about current connection object.
            Console.WriteLine("***** Info about your connection *****");
            Console.WriteLine($"Database location: {connection.DataSource}");
            Console.WriteLine($"Database name: {connection.Database}");
            Console.WriteLine($"Timeout: {connection.ConnectionTimeout}");
            Console.WriteLine($"Connection state: {connection.State}");
        }

        private static void ExecuteSQLCommands(SqlConnection connection)
        {
            // Create command object via constructor arguments.
            string sql =  @"select MeasurementId, MeasurementName, Unit from Measurement where MeasurementID = 1";
            SqlCommand myCommand = new SqlCommand(sql, connection);

            // Create another command object via properties.
            SqlCommand testCommand = new SqlCommand();
            testCommand.Connection = connection;
            testCommand.CommandText = sql;
        }
    }
}
