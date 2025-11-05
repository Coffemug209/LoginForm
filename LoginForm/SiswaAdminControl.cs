using LoginForm.Models;
using LoginForm.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class SiswaAdminControl : UserControl
    {
        private readonly UserRepository repo = new UserRepository();

        public SiswaAdminControl()
        {
            InitializeComponent();

            if (txtSrc != null)
            {
                txtSrc.TextChanged += new System.EventHandler(this.txtSrc_Text_Change);
            }

            ReadUserData();
            formatTable();
        }

        private void formatTable()
        {
            this.tableUser.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tableUser.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tableUser.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tableUser.Columns["Username"].DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.tableUser.Columns["Username"].DefaultCellStyle.Font = new Font(this.tableUser.Font, FontStyle.Bold);
            this.tableUser.Columns["Username"].ReadOnly = true;
            this.tableUser.Columns["Email"].ReadOnly = true;
            this.tableUser.Columns["Phone"].ReadOnly = true;
            this.tableUser.Columns["id"].ReadOnly = true;
            this.tableUser.Columns["id"].Visible = false;
            this.tableUser.Columns["Edit"].DisplayIndex = tableUser.Columns.Count - 1;
            this.tableUser.Columns["Delete"].DisplayIndex = tableUser.Columns.Count - 1;
        }


        private void ReadUserData(string searchTerm = null)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Username");
            dt.Columns.Add("Email");
            dt.Columns.Add("Phone");

            var userList = repo.GetUserList();
            IEnumerable<User> filteredUserList = userList;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string lowerSearch = txtSrc.Text.ToLower().Trim();
                filteredUserList = userList.Where(u => u.username != null && u.username.ToLower().Contains(lowerSearch));
            }

            foreach (var user in filteredUserList)
            {
                var row = dt.NewRow();
                row["Id"] = user.id;
                row["Username"] = user.username;
                row["Email"] = user.email;
                row["Phone"] = user.phone;

                dt.Rows.Add(row);

                this.tableUser.DataSource = dt;
            }
        }

        private void tableUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var val = this.tableUser.Rows[e.RowIndex].Cells["id"].Value.ToString();
            if (string.IsNullOrEmpty(val)) return;

            int userId = int.Parse(val);
            var user = repo.GetUser(userId);

            if (user == null) return;

            var columnName = tableUser.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit" && e.RowIndex >= 0)
            {
                CreateEdit form = new CreateEdit();
                form.editUser(user);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReadUserData();
                }
            }
            else if (columnName == "Delete" && e.RowIndex >= 0)
            {
                repo.DeleteUser(user);
                ReadUserData();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            CreateEdit p = new CreateEdit();
            if (p.ShowDialog() == DialogResult.OK)
            {
                ReadUserData();
            }
        }

        private void SiswaAdminControl_Load(object sender, System.EventArgs e)
        {

        }

        private void txtSrc_Text_Change(object sender, System.EventArgs e)
        {
            ReadUserData(txtSrc.Text);
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            ReadUserData();
        }
    }
}
