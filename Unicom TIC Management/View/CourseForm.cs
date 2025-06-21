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
    public partial class CourseForm : Form
    {
        private int selectedcourseid = -1;
        Coursecontroller coursecontroller;
        public CourseForm()
        {
            InitializeComponent();
            coursecontroller = new Coursecontroller();
        }

        private void LoadCoursesToGrid()
        {
            dgvcourse.DataSource = Coursecontroller.GetCourseList();

            this.BeginInvoke(new Action(() =>
            {
                dgvcourse.ClearSelection();
                dgvcourse.CurrentCell = null;
                selectedcourseid = -1;
                txtname.Clear();
            }));
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("Course Name Cannot be empty!", "Error", MessageBoxButtons.OK);
                return;
            }
            Course course = new Course
            {
                Name = txtname.Text.Trim()
            };
            coursecontroller.Addcourse(course);

            txtname.Clear();
            LoadCoursesToGrid();
        }

        private void dgvcourse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvcourse.SelectedRows.Count == 0 || dgvcourse.CurrentCell == null)
            {
                selectedcourseid = -1;
                txtname.Clear();
                return;
            }

            var row = dgvcourse.SelectedRows[0];
            var courseview = row.DataBoundItem as Course;

            if (courseview != null)
            {
                selectedcourseid = courseview.Id;

                var course = coursecontroller.GetCourseById(courseview.Id);
                if (course != null)
                {
                    txtname.Text = course.Name;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedcourseid <= 0)
            {
                MessageBox.Show("Select a Course to delete!", "Error", MessageBoxButtons.OK);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                coursecontroller.DeleteCourse(selectedcourseid);
            }

            selectedcourseid = -1;
            txtname.Clear();
            LoadCoursesToGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadCoursesToGrid();
        }
    }
}