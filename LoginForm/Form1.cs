using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=form_db;Integrated Security=True";

        private string placeholderUser = "Username";
        private string placeholderPass = "Password";


        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == placeholderUser)
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Text = placeholderUser;
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar == true)
            {
                txtPass.UseSystemPasswordChar = false;
                pictureBox1.Image = Properties.Resources.icon_show;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                pictureBox1.Image = Properties.Resources.icon_hide;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            if (txtPass.Text == placeholderPass)
            {
                txtPass.Clear();
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text = placeholderPass;
                txtPass.ForeColor = Color.Gray;
            }
        }

        private string getUsername(string username)
        {
            string q = "SELECT username FROM [user] WHERE username=@username";
            string user = null;

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            user = result.ToString();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
            return user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = txtPass.Text;
            string username = txtUsername.Text;
            bool dUser = getUsername(username) == username;
            string q = "INSERT INTO [user](username,password) VALUES(@username, @password)";

            if (txtUsername.Text != placeholderUser && txtPass.Text != placeholderPass)
            {
                if (!dUser)
                {

                    string pass = txtPass.Text.ToString();
                    string hashedPass = BCrypt.Net.BCrypt.HashPassword(pass, 13);

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(q, con))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.ToString());
                            cmd.Parameters.AddWithValue("@password", hashedPass);

                            try
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Connection Success");
                                txtUsername.Clear();
                                txtPass.Clear();
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
                    }
                }
                else
                {
                    MessageBox.Show("Username already exist");
                    txtPass.Clear();
                    txtUsername.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please fill in the form!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 p = new Form2();
            p.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}