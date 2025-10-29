using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=form_db;Integrated Security=True";

        private string placeholderUser = "Username";
        private string placeholderPass = "Password";

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

        private void Form2_Load(object sender, EventArgs e)
        {

            txtUsername.Text = placeholderUser;
            txtUsername.ForeColor = Color.Gray;
            txtPass.UseSystemPasswordChar = false;
            txtPass.Text = placeholderPass;
            txtPass.ForeColor = Color.Gray;
        }

        private string getHashedPass(string username)
        {
            string q = "SELECT password FROM [user] WHERE username=@username";
            string hashedPass = null;

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
                            hashedPass = result.ToString();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
            }
            return hashedPass;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == placeholderUser || txtPass.Text == placeholderPass)
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }

            string username = txtUsername.Text;
            string password = txtPass.Text;
            string hashedPass = getHashedPass(username);

            if (hashedPass != null)
            {
                try
                {
                    bool validatePass = BCrypt.Net.BCrypt.Verify(password, hashedPass);

                    if (validatePass)
                    {
                        AdminDashboard p = new AdminDashboard(username);
                        p.Show();
                        this.Hide();
                        txtUsername.Clear();
                        txtPass.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                        txtPass.Text = placeholderPass;
                        txtUsername.Text = placeholderUser;
                    }
                }
                catch (BCrypt.Net.SaltParseException ex)
                {
                    MessageBox.Show("Login failed due to bad password configuration. Contact support.");
                    txtPass.Text = placeholderPass;
                    txtUsername.Text = placeholderUser;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                txtPass.Text = placeholderPass;
                txtUsername.Text = placeholderUser;
            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 p = new Form1();
            p.Show();
            this.Hide();
        }
    }
}