using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CreateEdit : Form
    {
        public CreateEdit()
        {
            InitializeComponent();
        }

        private string placeholderUser = "Username";
        private string placeholderPass = "Password";
        private string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=form_db;Integrated Security=True";


        private void txtUsername_Enter_1(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPass.Clear();
        }

        private string getUsername(string username)
        {
            string q = "SELECT username FROM [user] WHERE @username=username";
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
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.ToString();
            string password = txtPass.Text.ToString();
            bool dUser = getUsername(username) == username;
            string q = "INSERT INTO [user](username,password) VALUES(@username,@password)";

            if (password != placeholderPass && username != placeholderUser)
            {
                if (!dUser)
                {
                    string hashedPass = BCrypt.Net.BCrypt.HashPassword(password, 13);
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(q, con))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@passwrod", hashedPass);
                        }
                    }
                }
            }
        }
    }
}