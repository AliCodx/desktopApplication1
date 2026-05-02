using System.Windows.Forms;
using System.Drawing;

namespace StudentManagementSystemProject.Forms
{
    partial class CreateUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private ComboBox cmbRole;
        private Button btnCreate;
        private Button btnCancel;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.txtFullName = new TextBox();
            this.cmbRole = new ComboBox();
            this.btnCreate = new Button();
            this.btnCancel = new Button();
            this.lblTitle = new Label();

            this.SuspendLayout();
            // 
            // CreateUserForm
            // 
            this.ClientSize = new Size(520, 320);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Create New User";
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.BackColor = Color.White;

            // Title
            lblTitle.Text = "Create New User";
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.AutoSize = false;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            this.Controls.Add(lblTitle);

            // Username
            var lblUser = new Label();
            lblUser.Text = "Username";
            lblUser.Location = new Point(40, 80);
            this.Controls.Add(lblUser);
            txtUsername.Location = new Point(40, 100);
            txtUsername.Size = new Size(440, 28);
            txtUsername.PlaceholderText = "Enter username";
            this.Controls.Add(txtUsername);

            // Password
            var lblPass = new Label();
            lblPass.Text = "Password";
            lblPass.Location = new Point(40, 140);
            this.Controls.Add(lblPass);
            txtPassword.Location = new Point(40, 160);
            txtPassword.Size = new Size(440, 28);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.PlaceholderText = "Enter password";
            this.Controls.Add(txtPassword);

            // Full name
            var lblFull = new Label();
            lblFull.Text = "Full Name";
            lblFull.Location = new Point(40, 200);
            this.Controls.Add(lblFull);
            txtFullName.Location = new Point(40, 220);
            txtFullName.Size = new Size(440, 28);
            txtFullName.PlaceholderText = "Optional";
            this.Controls.Add(txtFullName);

            // Role
            var lblRole = new Label();
            lblRole.Text = "Role";
            lblRole.Location = new Point(40, 260);
            this.Controls.Add(lblRole);
            cmbRole.Location = new Point(40, 280);
            cmbRole.Size = new Size(200, 28);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "User", "Admin", "Staff" });
            cmbRole.SelectedIndex = 0;
            this.Controls.Add(cmbRole);

            // Buttons
            btnCreate.Location = new Point(320, 280);
            btnCreate.Size = new Size(80, 28);
            btnCreate.Text = "Create";
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.BackColor = Color.FromArgb(34, 139, 230);
            btnCreate.ForeColor = Color.White;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.Controls.Add(btnCreate);

            btnCancel.Location = new Point(410, 280);
            btnCancel.Size = new Size(70, 28);
            btnCancel.Text = "Cancel";
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.BackColor = Color.FromArgb(220, 220, 220);
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Controls.Add(btnCancel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
