using System;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class HomeAdminControl : UserControl
    {
        public HomeAdminControl()
        {
            InitializeComponent();

            this.Resize += new System.EventHandler(this.HomeUserControl_Resize);
            pictureCenter();
        }

        private void pictureCenter()
        {
            int y = (this.Height - pictureBox1.Height) / 2;
            int x = (this.Width - pictureBox1.Width) / 2;

            pictureBox1.Location = new System.Drawing.Point(x, y);

        }

        private void HomeUserControl_Resize(object sender, System.EventArgs e)
        {
            pictureCenter();
        }

        private void HomeAdminControl_Load(object sender, EventArgs e)
        {

        }
    }
}
