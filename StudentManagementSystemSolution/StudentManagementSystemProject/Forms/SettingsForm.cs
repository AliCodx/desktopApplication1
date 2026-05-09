using System;
using System.Windows.Forms;
using StudentManagementSystemProject.DAL;

namespace StudentManagementSystemProject.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly string _username;
        private readonly UserDAL _userDal = new UserDAL();

        public SettingsForm(string username)
        {
            _username = username;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = _username;
            txtUsername.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var full = txtFullName.Text.Trim();
            var pw = txtPassword.Text;
            if (string.IsNullOrEmpty(pw))
            {
                MessageBox.Show("Password cannot be empty", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (_userDal.UpdateUser(_username, full, pw))
                {
                    MessageBox.Show("Profile updated", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update profile", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
