using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Controllers;
using Unicom_TIC_Management.Models;

namespace Unicom_TIC_Management.View
{
    public partial class StudentForm : Form
    {
        private int selectedStudentId = -1;
        private int selectedUserId = -1;
        private List<Student> studentList;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void LoadCoursesToComboBox()
        {
            cobcourse.DataSource = Coursecontroller.GetCourseList();
            cobcourse.DisplayMember = "Name";
            cobcourse.ValueMember = "ID";
            cobcourse.SelectedIndex = -1;
        }

        private void LoadGrid()
        {
            studentList = Studentcontroller.GetAll();
            dgvstudent.DataSource = studentList.Select(s => new
            {
                s.Id,
                s.Name,
                s.NIC,
                s.Coursename
            }).ToList();
            dgvstudent.ClearSelection();
        }

        private void ClearForm()
        {
            txtname.Clear();
            txtnic.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            cobcourse.SelectedIndex = -1;
            selectedStudentId = -1;
            selectedUserId = -1;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtnic.Text) ||
                string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text) ||
                cobcourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidNIC(txtnic.Text))
            {
                MessageBox.Show("Invalid NIC format.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }
        private bool IsValidNIC(string nic)
        {
            var oldNicPattern = @"^\d{9}[vVxX]$";
            var newNicPattern = @"^\d{12}$";
            return Regex.IsMatch(nic, oldNicPattern) || Regex.IsMatch(nic, newNicPattern);
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (Usercontroller.IsNICUsed(txtnic.Text))
            {
                MessageBox.Show("NIC already exists in system.");
                return;
            }
            if (!ValidateForm()) return;

            var student = new Student
            {
                Name = txtname.Text.Trim(),
                NIC = txtnic.Text.Trim(),
                Username = txtusername.Text.Trim(),
                Password = txtpassword.Text.Trim(),
                CourseId = Convert.ToInt32(cobcourse.SelectedValue)
            };

            new Studentcontroller().AddStudent(student);
            LoadGrid();
            ClearForm();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                ClearForm();
                return;
            }
            

            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure to delete this student?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                new Studentcontroller().DeleteStudent(selectedStudentId);
                LoadGrid();
                ClearForm();
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (Usercontroller.IsNICUsedByOthers(txtnic.Text.Trim(), "Students", selectedStudentId))
            {
                MessageBox.Show("NIC already exists in system.");
                return;
            }
            if (selectedStudentId == -1 || !ValidateForm()) return;

            var updated = new Student
            {
                Id = selectedStudentId,
                UserID = selectedUserId,
                Name = txtname.Text.Trim(),
                NIC = txtnic.Text.Trim(),
                Username = txtusername.Text.Trim(),
                Password = txtpassword.Text.Trim(),
                CourseId = Convert.ToInt32(cobcourse.SelectedValue)
            };

            new Studentcontroller().UpdateStudent(updated);
            LoadGrid();
            ClearForm();
        }

        private void dgvstudent_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvstudent.SelectedRows.Count == 0) return;

            var id = Convert.ToInt32(dgvstudent.SelectedRows[0].Cells["Id"].Value);
            var student = studentList.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                selectedStudentId = student.Id;
                selectedUserId = student.UserID;
                txtname.Text = student.Name;
                txtnic.Text = student.NIC;
                txtusername.Text = student.Username;
                txtpassword.Text = student.Password;
                cobcourse.SelectedValue = student.CourseId;
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadCoursesToComboBox();
            LoadGrid();
            ClearForm();
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
