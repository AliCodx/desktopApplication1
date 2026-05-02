using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using StudentManagementSystemProject.Data;
using StudentManagementSystemProject.Models;

namespace StudentManagementSystemProject.DAL
{
    public class StudentDAL
    {
        // Get all students
        public List<Student> GetAll()
        {
            var list = new List<Student>();
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("SELECT Id, Name, Email, Phone, Gender, DateOfBirth, Address FROM Students", conn))
            {
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Student
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                            Email = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                            Phone = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                            Gender = rdr.IsDBNull(4) ? string.Empty : rdr.GetString(4),
                            DateOfBirth = rdr.IsDBNull(5) ? (DateTime?)null : rdr.GetDateTime(5),
                            Address = rdr.IsDBNull(6) ? string.Empty : rdr.GetString(6)
                        });
                    }
                }
            }
            return list;
        }

        public bool Add(Student s)
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("INSERT INTO Students (Name, Email, Phone, Gender, DateOfBirth, Address) VALUES (@Name, @Email, @Phone, @Gender, @DateOfBirth, @Address)", conn))
            {
                cmd.Parameters.AddWithValue("@Name", s.Name);
                cmd.Parameters.AddWithValue("@Email", s.Email);
                cmd.Parameters.AddWithValue("@Phone", (object)s.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object)s.Gender ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", s.DateOfBirth.HasValue ? (object)s.DateOfBirth.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)s.Address ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(Student s)
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("UPDATE Students SET Name=@Name, Email=@Email, Phone=@Phone, Gender=@Gender, DateOfBirth=@DateOfBirth, Address=@Address WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Name", s.Name);
                cmd.Parameters.AddWithValue("@Email", s.Email);
                cmd.Parameters.AddWithValue("@Phone", (object)s.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object)s.Gender ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", s.DateOfBirth.HasValue ? (object)s.DateOfBirth.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)s.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", s.Id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("DELETE FROM Students WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Search by name or id
        public List<Student> Search(string term)
        {
            var list = new List<Student>();
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("SELECT Id, Name, Email, Phone, Gender, DateOfBirth, Address FROM Students WHERE Name LIKE @term OR CAST(Id AS CHAR)=@termExact", conn))
            {
                cmd.Parameters.AddWithValue("@term", "%" + term + "%");
                cmd.Parameters.AddWithValue("@termExact", term);
                conn.Open();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new Student
                        {
                            Id = rdr.GetInt32(0),
                            Name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                            Email = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                            Phone = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                            Gender = rdr.IsDBNull(4) ? string.Empty : rdr.GetString(4),
                            DateOfBirth = rdr.IsDBNull(5) ? (DateTime?)null : rdr.GetDateTime(5),
                            Address = rdr.IsDBNull(6) ? string.Empty : rdr.GetString(6)
                        });
                    }
                }
            }
            return list;
        }

        public int GetCount()
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand("SELECT COUNT(1) FROM Students", conn))
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
