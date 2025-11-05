using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard(string username)
        {
            InitializeComponent();
            txtUser.Text = username;

            SwitchControl(new HomeAdminControl());
        }

        public void SwitchControl(UserControl newControl)
        {
            pnlContent.Controls.Clear();
            newControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(newControl);
        }

        private void txtUser_Click(object sender, EventArgs e)
        {

        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 p = new Form1();
            this.Hide();
            p.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }



        private void HighlightButton(Button clickedButton)
        {
            foreach (Control control in clickedButton.Parent.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = Color.WhiteSmoke;
                    button.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    button.ForeColor = Color.Black;
                }

                clickedButton.BackColor = Color.SteelBlue;
                clickedButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                clickedButton.ForeColor = Color.Black;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SwitchControl(new HomeAdminControl());
            HighlightButton(btnHome);
        }

        private void btnSiswa_Click(object sender, EventArgs e)
        {
            SwitchControl(new SiswaAdminControl());
            HighlightButton(btnSiswa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
