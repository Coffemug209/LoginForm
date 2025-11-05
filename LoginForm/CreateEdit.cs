using LoginForm.Models;
using LoginForm.Repositories;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CreateEdit : Form
    {
        public CreateEdit()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private string placeholderUser = "Username";
        private string placeholderPass = "Password";
        private string placeholderEmail = "Email";
        private string placeholderPhone = "Phone";

        private void txtUsername_Enter_1(object sender, EventArgs e)
        {
            if (txtUsername.Text == placeholderUser)
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
            else
            {
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPass.Clear();
        }

        private int userId = 0;

        public void editUser(User user)
        {
            this.txtUsername.Text = user.username;
            this.txtEmail.Text = user.email;
            this.txtPhone.Text = "" + user.phone;
            this.userId = user.id;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string phoneText = txtPhone.Text;

            User user = new User();
            user.id = userId;
            user.username = txtUsername.Text;
            user.email = txtEmail.Text;
            user.phone = int.Parse(phoneText);
            user.password = BCrypt.Net.BCrypt.HashPassword(txtPass.Text, 13);

            var repo = new UserRepository();
            if (user.id == 0)
            {
                repo.CreateUser(user);
            }
            else
            {
                repo.UpdateUser(user);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void CreateEdit_Load(object sender, EventArgs e)
        {

        }
    }
}