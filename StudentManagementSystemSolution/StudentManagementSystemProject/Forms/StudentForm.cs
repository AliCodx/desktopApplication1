using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentManagementSystemProject.DAL;
using StudentManagementSystemProject.Models;

namespace StudentManagementSystemProject.Forms
{
    public partial class StudentForm : Form
    {
        private readonly StudentDAL _dal = new StudentDAL();
        private List<Student> _students = new List<Student>();

        public StudentForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                _students = _dal.GetAll();
                dgvStudents.DataSource = _students;
                lblCount.Text = $"Total: {_students.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out var student)) return;
            if (_dal.Add(student))
            {
                MessageBox.Show("Student added");
                LoadStudents();
                ClearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out var id))
            {
                MessageBox.Show("Select a student to update");
                return;
            }

            if (!ValidateInputs(out var student)) return;
            student.Id = id;
            if (_dal.Update(student))
            {
                MessageBox.Show("Student updated");
                LoadStudents();
                ClearInputs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out var id))
            {
                MessageBox.Show("Select a student to delete");
                return;
            }
            if (MessageBox.Show("Delete selected student?","Confirm",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if (_dal.Delete(id))
                {
                    MessageBox.Show("Deleted");
                    LoadStudents();
                    ClearInputs();
                }
            }
        }

        private bool ValidateInputs(out Student s)
        {
            s = null;
            var name = txtName.Text.Trim();
            var email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required");
                return false;
            }
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                MessageBox.Show("Valid email is required");
                return false;
            }
            // Read gender and dob from controls
            var cmbGender = this.Controls.Find("cmbGender", true).FirstOrDefault() as ComboBox;
            var dtpDob = this.Controls.Find("dtpDob", true).FirstOrDefault() as DateTimePicker;
            var gender = cmbGender != null ? cmbGender.SelectedItem?.ToString() ?? string.Empty : string.Empty;
            DateTime? dob = null;
            if (dtpDob != null) dob = dtpDob.Value.Date;

            s = new Student
            {
                Name = name,
                Email = email,
                Phone = txtPhone.Text.Trim(),
                Gender = gender,
                DateOfBirth = dob,
                Address = txtAddress.Text.Trim()
            };
            return true;
        }

        private void ClearInputs()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            var cmbGender = this.Controls.Find("cmbGender", true).FirstOrDefault() as ComboBox;
            if (cmbGender != null) cmbGender.SelectedIndex = 0;
            var dtpDob = this.Controls.Find("dtpDob", true).FirstOrDefault() as DateTimePicker;
            if (dtpDob != null) dtpDob.Value = DateTime.Today;
            txtPhone.Text = "";
            txtAddress.Text = "";
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            var s = dgvStudents.CurrentRow.DataBoundItem as Student;
            if (s == null) return;
            txtId.Text = s.Id.ToString();
            txtName.Text = s.Name;
            txtEmail.Text = s.Email;
            var cmbGender = this.Controls.Find("cmbGender", true).FirstOrDefault() as ComboBox;
            if (cmbGender != null) cmbGender.SelectedItem = string.IsNullOrEmpty(s.Gender) ? null : s.Gender;
            var dtpDob = this.Controls.Find("dtpDob", true).FirstOrDefault() as DateTimePicker;
            if (dtpDob != null) dtpDob.Value = s.DateOfBirth ?? DateTime.Today;
            txtPhone.Text = s.Phone;
            txtAddress.Text = s.Address;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var term = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(term))
            {
                LoadStudents();
                return;
            }
            var results = _dal.Search(term);
            dgvStudents.DataSource = results;
            lblCount.Text = $"Total: {results.Count}";
        }
    }
}
