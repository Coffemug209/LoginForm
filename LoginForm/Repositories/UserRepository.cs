using LoginForm.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm.Repositories
{
    internal class UserRepository
    {
        private readonly string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=form_db;Integrated Security=True";

        public List<User> GetUserList()
        {
            var UserList = new List<User>();
            try
            {
                string q = "SELECT * FROM [user] ORDER BY id ASC";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.id = reader.GetInt32(0);
                                user.username = reader.GetString(1);
                                user.password = reader.GetString(2);
                                user.email = reader.GetString(3);
                                user.phone = reader.GetInt32(4);

                                UserList.Add(user);
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            return UserList;
        }

        public User GetUser(int id)
        {
            string q = "SELECT * FROM [user] WHERE @id=id";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User();
                                user.id = reader.GetInt32(0);
                                user.username = reader.GetString(1);
                                user.password = reader.GetString(2);
                                user.email = reader.GetString(3);
                                user.phone = reader.GetInt32(4);

                                return user;
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

            return null;
        }

        public void CreateUser(User user)
        {
            string q = "INSERT INTO [user](username,password,email,phone) VALUES(@username,@password,@email,@phone)";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@username", user.username);
                        cmd.Parameters.AddWithValue("@password", user.password);
                        cmd.Parameters.AddWithValue("@email", user.email);
                        cmd.Parameters.AddWithValue("@phone", user.phone);

                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void UpdateUser(User user)
        {
            string q = "UPDATE [user] SET username=@username, password=@password, email=@email, phone=@phone WHERE id=@id";

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        con.Open();

                        cmd.Parameters.AddWithValue("@username", user.username);
                        cmd.Parameters.AddWithValue("@password", user.password);
                        cmd.Parameters.AddWithValue("@email", user.email);
                        cmd.Parameters.AddWithValue("@phone", user.phone);
                        cmd.Parameters.AddWithValue("@id", user.id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void DeleteUser(User user)
        {
            string q = "DELETE FROM [user] WHERE @id=id";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@id", user.id);
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
