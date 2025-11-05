using LoginForm.Models;
using LoginForm.Repositories;
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

        private string placeholderUser = "Username";
        private string placeholderPass = "Password";
        private string placeholderEmail = "Email";
        private string placeholderPhone = "Phone";

        private string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=form_db;Integrated Security=True";


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
            var user = new User();

            string password = user.password = BCrypt.Net.BCrypt.HashPassword(txtPass.Text, 13);
            string username = user.username = txtUsername.Text;
            user.email = txtEmail.Text;
            user.phone = int.Parse(txtPhone.Text);
            bool dUser = getUsername(username) == username;

            if (txtPass.Text != null || txtUsername != null)
            {
                if (!dUser)
                {
                    var repo = new UserRepository();
                    repo.CreateUser(user);

                    AdminDashboard p = new AdminDashboard(username);
                    p.Show();
                    this.Hide();
                    txtUsername.Clear();
                    txtPass.Clear();
                }
                else
                {
                    MessageBox.Show("Username already taken");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the form");
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

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == placeholderEmail)
            {
                txtEmail.Clear();
                txtEmail.ForeColor = Color.Black;
            }
            else
            {
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.Text = placeholderEmail;
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == placeholderPhone)
            {
                txtPhone.Clear();
                txtPhone.ForeColor = Color.Black;
            }
            else
            {
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Text = placeholderPhone;
                txtPhone.ForeColor = Color.Gray;
            }
        }
    }
}