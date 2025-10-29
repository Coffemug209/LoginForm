namespace LoginForm
{
    partial class SiswaAdminControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tableUser = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.userRepositoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userRepositoryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRepositoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRepositoryBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Siswa - Master Data";
            // 
            // tableUser
            // 
            this.tableUser.AllowUserToResizeColumns = false;
            this.tableUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tableUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tableUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tableUser.ColumnHeadersHeight = 30;
            this.tableUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.tableUser.Location = new System.Drawing.Point(42, 117);
            this.tableUser.Name = "tableUser";
            this.tableUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tableUser.RowHeadersVisible = false;
            this.tableUser.RowTemplate.Height = 30;
            this.tableUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableUser.Size = new System.Drawing.Size(716, 318);
            this.tableUser.TabIndex = 1;
            this.tableUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableUser_CellContentClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            // 
            // Edit
            // 
            this.Edit.ActiveLinkColor = System.Drawing.Color.Coral;
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit.HeaderText = "Edit";
            this.Edit.LinkColor = System.Drawing.Color.Coral;
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            this.Edit.VisitedLinkColor = System.Drawing.Color.Coral;
            // 
            // userRepositoryBindingSource
            // 
            this.userRepositoryBindingSource.DataSource = typeof(LoginForm.Repositories.UserRepository);
            // 
            // userRepositoryBindingSource1
            // 
            this.userRepositoryBindingSource1.DataSource = typeof(LoginForm.Repositories.UserRepository);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(614, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "ADD SISWA +";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SiswaAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableUser);
            this.Controls.Add(this.label1);
            this.Name = "SiswaAdminControl";
            this.Size = new System.Drawing.Size(807, 509);
            ((System.ComponentModel.ISupportInitialize)(this.tableUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRepositoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRepositoryBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tableUser;
        private System.Windows.Forms.BindingSource userRepositoryBindingSource;
        private System.Windows.Forms.BindingSource userRepositoryBindingSource1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.Button button1;
    }
}
