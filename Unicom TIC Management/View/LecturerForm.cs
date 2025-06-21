using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Unicom_TIC_Management.Controllers;
using Unicom_TIC_Management.Models;

namespace Unicom_TIC_Management.View
{
    public partial class LecturerForm : Form
    {
        private int selectedlecturerid;
        private List<Lecturer> fullLecturerList = new List<Lecturer>();

        public LecturerForm()
        {
            InitializeComponent();
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadLecturersToGrid();
        }

        private void LoadLecturersToGrid()
        {
            fullLecturerList = Lecturercontroller.AllLecturer();

            var data = fullLecturerList
                .Select(l => new
                {
                    l.Id,
                    l.Name,
                    l.NIC
                })
                .ToList();

            dgvlecturer.DataSource = data;

        }



        private void ClearForm()
        {
            txtname.Clear();
            txtnic.Clear();
            txtusername.Clear();
            txtpassword.Clear();
        }

        private bool IsValidNIC(string nic)
        {
            nic = nic.Trim();

            var oldNicPattern = @"^\d{9}[vVxX]$";
            var newNicPattern = @"^\d{12}$";

            return System.Text.RegularExpressions.Regex.IsMatch(nic, oldNicPattern) ||
                   System.Text.RegularExpressions.Regex.IsMatch(nic, newNicPattern);
        }


        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
            string.IsNullOrWhiteSpace(txtnic.Text) ||
            string.IsNullOrWhiteSpace(txtusername.Text) ||
            string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Please fill all the fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidNIC(txtnic.Text))
            {
                MessageBox.Show("Invalid NIC number. Please enter a valid NIC.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Lecturer lecturer = new Lecturer
            {
                Name = txtname.Text.Trim(),
                NIC = txtnic.Text.Trim(),
                Username = txtusername.Text.Trim(),
                Password = txtpassword.Text.Trim()
            };
            Lecturercontroller controller = new Lecturercontroller();
            controller.AddUser(lecturer);

            ClearForm();
            LoadLecturersToGrid();
        }

        private void dgvlecturer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvlecturer.SelectedRows.Count > 0)
            {
                var row = dgvlecturer.SelectedRows[0];
                int selectedId = Convert.ToInt32(row.Cells["Id"].Value);

                var lecturer = fullLecturerList.FirstOrDefault(l => l.Id == selectedId);
                if (lecturer != null)
                {
                    selectedlecturerid = lecturer.Id;
                    txtname.Text = lecturer.Name;
                    txtnic.Text = lecturer.NIC;
                    txtusername.Text = lecturer.Username;
                    txtpassword.Text = lecturer.Password;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedlecturerid == -1)
            {
                MessageBox.Show("Please select a lecturer to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtname.Text)||
                string.IsNullOrWhiteSpace(txtnic.Text)||
                string.IsNullOrWhiteSpace(txtusername.Text)||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this lecturer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                var controller = new Lecturercontroller();
                bool isDeleted = controller.DeleteLecturer(selectedlecturerid);

                if (isDeleted)
                {
                    MessageBox.Show("Lecturer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedlecturerid = -1;
                    ClearForm();
                    LoadLecturersToGrid();
                }
                else
                {
                    MessageBox.Show("Lecturer not found or deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (selectedlecturerid == -1)
            {
                MessageBox.Show("Please select a lecturer to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtnic.Text) ||
                string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var original = fullLecturerList.FirstOrDefault(l => l.Id == selectedlecturerid);
            if (original == null)
            {
                MessageBox.Show("Lecturer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = txtname.Text.Trim();
            string nic = txtnic.Text.Trim();
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (!IsValidNIC(nic))
            {
                MessageBox.Show("Invalid NIC number. Please enter a valid NIC.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (name == original.Name &&
                nic == original.NIC &&
                username == original.Username &&
                password == original.Password)
            {
                MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Lecturer updated = new Lecturer
            {
                Id = selectedlecturerid,
                Name = name,
                NIC = nic,
                Username = username,
                Password = password
            };

            Lecturercontroller controller = new Lecturercontroller();
            controller.UpdateLecturer(updated);

            MessageBox.Show("Lecturer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
            LoadLecturersToGrid();
        }

        private void linkbtn_Click(object sender, EventArgs e)
        {
            LecturerSubjectForm lecturerSubjectForm = new LecturerSubjectForm();
            lecturerSubjectForm.ShowDialog();
            
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
