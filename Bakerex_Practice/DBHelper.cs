using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakerex_Practice
{
    public static class DBHelper
    {
        private static readonly string connectionString = "Server=YOUR_SERVER;Database=YOUR_DATABASE;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            var conn = new SqlConnection(connectionString);
            var adapter = new SqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }

        public static SqlDataReader ExecuteReader(string query, SqlParameter[] parameters)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddRange(parameters);
            conn.Open();

            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn); 

            cmd.Parameters.AddRange(parameters);
            conn.Open();

            return cmd.ExecuteNonQuery(); 
        }

    }
}
