using System.Windows.Forms;
using System.Drawing;

namespace StudentManagementSystemProject.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.txtUsername = new TextBox();
            this.txtFullName = new TextBox();
            this.txtPassword = new TextBox();
            this.btnSave = new Button();

            this.SuspendLayout();
            this.ClientSize = new Size(380, 180);
            this.Text = "Settings";
            this.StartPosition = FormStartPosition.CenterParent;

            var lblUser = new Label() { Text = "Username:", Location = new Point(12, 12), Size = new Size(80, 22) };
            this.txtUsername.Location = new Point(100, 12);
            this.txtUsername.Size = new Size(260, 22);

            var lblFull = new Label() { Text = "Full name:", Location = new Point(12, 44), Size = new Size(80, 22) };
            this.txtFullName.Location = new Point(100, 44);
            this.txtFullName.Size = new Size(260, 22);

            var lblPass = new Label() { Text = "Password:", Location = new Point(12, 76), Size = new Size(80, 22) };
            this.txtPassword.Location = new Point(100, 76);
            this.txtPassword.Size = new Size(260, 22);
            this.txtPassword.UseSystemPasswordChar = true;

            this.btnSave.Location = new Point(260, 110);
            this.btnSave.Size = new Size(100, 28);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.Controls.Add(lblUser);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(lblFull);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(lblPass);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnSave);

            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
