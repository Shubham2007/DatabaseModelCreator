using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseModelCreator
{
    static class DatabaseHelper
    {
        /// <summary>
        /// Fetch the tables from the database
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static List<string> FetchTables(string connString)
        {
            string cmdstr = "select * from sys.tables";

            DataTable dt = FetchItems(connString, cmdstr);
            List<string> tables = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                tables.Add(row["name"].ToString());
            }

            return tables;
        }

        /// <summary>
        /// Fetch the views from the database
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static List<string> FetchViews(string connString)
        {
            string cmdstr = "select * from sys.views";

            DataTable dt = FetchItems(connString, cmdstr);
            List<string> views = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                views.Add(row["name"].ToString());
            }

            return views;
        }

        /// <summary>
        /// Extract the database name from connection string
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static string ExtractDatabaseName(string connString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
            return builder.InitialCatalog;
        }

        /// <summary>
        /// Get the model as string from the database
        /// </summary>
        /// <returns></returns>
        public static string GetModelStringFromDatabase(string connString, string tableOrView)
        {
            string databaseName = ExtractDatabaseName(connString);
            string query = SqlQueries.GenerateModelScript().Replace("{0}", databaseName).Replace("{1}", tableOrView);
            string modelString = string.Empty;

            // Generate database entity model as string and save it int .cs format
            using (SqlConnection connection = new SqlConnection(connString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        modelString = reader["Model"].ToString();           
                    }
                }
            }

            return modelString;
        }

        /// <summary>
        /// Checks connection to database
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public static bool CheckValidConnection(string connString)
        {
            try
            {
                using (var connection = new SqlConnection(connString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #region PrivateMethods

        /// <summary>
        /// Fetch the items from the database based on query
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="cmdStr"></param>
        /// <returns></returns>
        private static DataTable FetchItems(string connString, string cmdStr)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmdStr, connString);

            sda.Fill(dt);
            return dt;
        }

        #endregion

    }
}
