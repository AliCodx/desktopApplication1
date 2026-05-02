using System;
using MySqlConnector;

namespace StudentManagementSystemProject.Data
{
    // Centralized DB connection helper for MySQL
    public static class DBConnection
    {
        // MySQL connection string - update as needed
        private static readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=studentdb;User=root;Password=Hello;SslMode=None;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
