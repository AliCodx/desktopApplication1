using System;
using MySqlConnector;
using StudentManagementSystemProject.Data;

namespace StudentManagementSystemProject.DAL
{
    public class UserDAL
    {
        // Authenticate user from Users table
        public bool Authenticate(string username, string password)
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("SELECT COUNT(1) FROM Users WHERE Username=@u AND Password=@p", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password); // For demo only. In production, store hashed passwords.
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Create a new user. Returns true if created, false if not (e.g., username exists)
        public bool CreateUser(string username, string password, string fullName, string role)
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("INSERT INTO Users (Username, Password, FullName, Role) VALUES (@u, @p, @f, @r)", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password); // demo: store plain text. Replace with hash in production.
                cmd.Parameters.AddWithValue("@f", string.IsNullOrEmpty(fullName) ? (object)DBNull.Value : fullName);
                cmd.Parameters.AddWithValue("@r", string.IsNullOrEmpty(role) ? (object)DBNull.Value : role);
                conn.Open();
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    // Duplicate entry or other DB errors will be handled by caller
                    return false;
                }
            }
        }
    }
}
