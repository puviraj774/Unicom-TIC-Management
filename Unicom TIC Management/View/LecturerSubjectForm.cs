using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Controllers;
using Unicom_TIC_Management.Models;

namespace Unicom_TIC_Management.View
{
    public partial class LecturerSubjectForm : Form
    {
        int selectedlecturersubjectid;
        private int selectedLecturerId;
        private int selectedSubjectId;

        public LecturerSubjectForm()
        {
            InitializeComponent();
        }

        private void LecturerSubjectForm_Load(object sender, EventArgs e)
        {
            LoadSubjectToCombobox();
            LoadLecturerToCombobox();
            LoadLecturerSubjectsToGrid();
        }
        private void LoadSubjectToCombobox()
        {
            cobsubject.DataSource = Subjectcontroller.AllSubjects();
            cobsubject.DisplayMember = "Name";
            cobsubject.ValueMember = "ID";
            cobsubject.SelectedIndex = -1;
        }
        private void LoadLecturerToCombobox()
        {
            coblecturer.DataSource = Lecturercontroller.AllLecturer();
            coblecturer.DisplayMember = "Name";
            coblecturer.ValueMember= "ID";
            coblecturer.SelectedIndex = -1;
        }
        private void LoadLecturerSubjectsToGrid()
        {
            dgvlecturersubject.DataSource = LecturerSubjectcontroller.GetAllLecturerSubjects();
            dgvlecturersubject.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (coblecturer.SelectedIndex == -1 || cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both Lecturer and Subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int lecturerId = Convert.ToInt32(coblecturer.SelectedValue);
            int subjectId = Convert.ToInt32(cobsubject.SelectedValue);

            var controller = new LecturerSubjectcontroller();
            bool added = controller.AddLecturerSubject(lecturerId, subjectId);

            if (!added)
            {
                MessageBox.Show("This subject is already assigned to the lecturer!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Subject assigned to lecturer successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadLecturerSubjectsToGrid();
            cobsubject.SelectedIndex = -1;
            coblecturer.SelectedIndex = -1;

        }

        private void dgvlecturersubject_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvlecturersubject.SelectedRows.Count == 0 || dgvlecturersubject.CurrentCell == null)
            {
                coblecturer.SelectedIndex = -1;
                cobsubject.SelectedIndex = -1;
                selectedLecturerId = -1;
                selectedSubjectId = -1;
                return;
            }
            var row = dgvlecturersubject.SelectedRows[0];
            string selectedLecturerName = row.Cells["Lecturer Name"].Value.ToString();
            string selectedSubjectName = row.Cells["Subject Name"].Value.ToString();

            foreach (var item in coblecturer.Items)
            {
                var lecturer = item as Lecturer;
                if (lecturer != null && lecturer.Name == selectedLecturerName)
                {
                    coblecturer.SelectedItem = lecturer;
                    selectedLecturerId = lecturer.Id;
                    break;
                }
            }
            foreach (var item in cobsubject.Items)
            {
                var subject = item as Subject;
                if (subject != null && subject.Name == selectedSubjectName)
                {
                    cobsubject.SelectedItem = subject;
                    selectedSubjectId = subject.Id;
                    break;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (coblecturer.SelectedIndex == -1 || cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both a lecturer and a subject to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int lecturerId = Convert.ToInt32(coblecturer.SelectedValue);
            int subjectId = Convert.ToInt32(cobsubject.SelectedValue);

            var confirm = MessageBox.Show("Are you sure you want to remove this assignment?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                var controller = new LecturerSubjectcontroller();
                bool deleted = controller.DeleteLecturerSubject(lecturerId, subjectId);

                if (deleted)
                    MessageBox.Show("Assignment deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No matching record found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLecturerSubjectsToGrid();

                coblecturer.SelectedIndex = -1;
                cobsubject.SelectedIndex = -1;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (coblecturer.SelectedIndex == -1 || cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both Lecturer and Subject to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int oldLecturerId = selectedLecturerId;
            int oldSubjectId = selectedSubjectId;

            int newLecturerId = Convert.ToInt32(coblecturer.SelectedValue);
            int newSubjectId = Convert.ToInt32(cobsubject.SelectedValue);

            if (oldLecturerId == newLecturerId && oldSubjectId == newSubjectId)
            {
                MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var controller = new LecturerSubjectcontroller();
            if (controller.LecturerSubjectExists(newLecturerId, newSubjectId))
            {
                MessageBox.Show("This assignment already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controller.DeleteLecturerSubject(oldLecturerId, oldSubjectId);
            controller.AddLecturerSubject(newLecturerId, newSubjectId);

            MessageBox.Show("Assignment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadLecturerSubjectsToGrid();

            coblecturer.SelectedIndex = -1;
            cobsubject.SelectedIndex = -1;
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
