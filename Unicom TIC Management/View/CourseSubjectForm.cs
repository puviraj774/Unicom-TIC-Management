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
    public partial class CourseSubjectForm : Form
    {
        private int selectedcoursesubjectid;
        public CourseSubjectForm()
        {
            InitializeComponent();
        }

        private void LoadSubjectToCombobox()
        {
            cobsubject.DataSource = Subjectcontroller.AllSubjects();
            cobsubject.DisplayMember = "Name";
            cobsubject.ValueMember = "ID";
            cobsubject.SelectedIndex = -1;
        }

        private void LoadCourseToCombobox()
        {
            cobcourse.DataSource = Coursecontroller.GetCourseList();
            cobcourse.DisplayMember = "Name";
            cobcourse.ValueMember = "ID";
            cobcourse.SelectedIndex = -1;
        }

        private void CourseSubjectForm_Load(object sender, EventArgs e)
        {
            LoadSubjectToCombobox();
            LoadCourseToCombobox();
            LoadToGrid();
        }

        private void LoadToGrid()
        {
            dgvcoursesubject.DataSource = CourseSubjectcontroller.All();
            dgvcoursesubject.Columns["SubjectId"].Visible = false;
            dgvcoursesubject.Columns["CourseId"].Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cobsubject.Text)||
                string.IsNullOrWhiteSpace(cobcourse.Text))
            {
                MessageBox.Show("Subject or Course Cannot be Empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            CourseSubject courseSubject = new CourseSubject
            {
                CourseId = Convert.ToInt32(cobcourse.SelectedValue),
                SubjectId = Convert.ToInt32(cobsubject.SelectedValue)
            };
            CourseSubjectcontroller controller = new CourseSubjectcontroller();
            controller.Add(courseSubject);

            LoadToGrid();
            cobcourse.SelectedIndex = -1;
            cobsubject.SelectedIndex = -1;
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvcoursesubject_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvcoursesubject.SelectedRows.Count == 0 || dgvcoursesubject.CurrentRow == null)
            {
                cobcourse.SelectedIndex = -1;
                cobsubject.SelectedIndex = -1;
                return;
            }

            var row = dgvcoursesubject.SelectedRows[0];
            var selectedItem = row.DataBoundItem as CourseSubject;

            if (selectedItem != null)
            {
                cobcourse.SelectedValue = selectedItem.CourseId;
                cobsubject.SelectedValue = selectedItem.SubjectId;
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvcoursesubject.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvcoursesubject.SelectedRows[0];
            var item = row.DataBoundItem as CourseSubject;

            if (item != null)
            {
                var confirm = MessageBox.Show(
                    $"Are you sure you want to unlink '{item.SubjectName}' from '{item.CourseName}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    CourseSubjectcontroller controller = new CourseSubjectcontroller();
                    controller.Delete(item.CourseId, item.SubjectId);

                    LoadToGrid();

                    cobcourse.SelectedIndex = -1;
                    cobsubject.SelectedIndex = -1;
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgvcoursesubject.SelectedRows.Count == 0 || dgvcoursesubject.CurrentRow == null)
            {
                MessageBox.Show("Please select a mapping to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dgvcoursesubject.SelectedRows[0];
            var oldMapping = row.DataBoundItem as CourseSubject;

            if (oldMapping == null)
            {
                MessageBox.Show("Invalid row selected.");
                return;
            }

            if (cobcourse.SelectedIndex == -1 || cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both Course and Subject.");
                return;
            }

            int newCourseId = Convert.ToInt32(cobcourse.SelectedValue);
            int newSubjectId = Convert.ToInt32(cobsubject.SelectedValue);

            if (newCourseId == oldMapping.CourseId && newSubjectId == oldMapping.SubjectId)
            {
                MessageBox.Show("No changes detected.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to update this mapping?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            CourseSubjectcontroller controller = new CourseSubjectcontroller();
            controller.UpdateCourseSubject(oldMapping.CourseId, oldMapping.SubjectId, newCourseId, newSubjectId);

            LoadToGrid();
            cobcourse.SelectedIndex = -1;
            cobsubject.SelectedIndex = -1;
        }
    }
}
