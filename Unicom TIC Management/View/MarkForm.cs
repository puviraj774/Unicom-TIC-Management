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
    public partial class MarkForm : Form
    {
        public MarkForm()
        {
            InitializeComponent();
        }

        private void MarkForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadExams(); // ExamTimetable
            LoadMarksGrid();
            LoadSubjects(); // Subjects
        }
        public void LoadStudents()
        {
            cobstudent.DataSource = Studentcontroller.GetIdAndNameOnly();
            cobstudent.DisplayMember = "Name";
            cobstudent.ValueMember = "ID";
            cobstudent.SelectedIndex = -1;
        }
        public void LoadSubjects()
        {
            cobsubject.DataSource = Subjectcontroller.GetIdAndNameOnly();
            cobsubject.DisplayMember = "Name";
            cobsubject.ValueMember = "ID";
            cobsubject.SelectedIndex = -1;
        }
        public void LoadExams()
        {
            cobexamname.DataSource = ExamTimetablecontroller.GetAll();
            cobexamname.DisplayMember = "ExamName"; // Combined name like "Midterm - Maths"
            cobexamname.ValueMember = "Id";
            cobexamname.SelectedIndex = -1;
        }


        public void LoadMarksGrid()
        {
            dgvmarks.DataSource = Markcontroller.GetAll();
            dgvmarks.Columns["ID"].Visible = false;
            dgvmarks.Columns["StudentID"].Visible = false;
            dgvmarks.Columns["ExamTimetableId"].Visible = false;
            dgvmarks.Columns["SubjectId"].Visible = false;
        }
        public void ClearForm()
        {
            cobstudent.SelectedIndex = -1;
            cobexamname.SelectedIndex = -1;
            cobsubject.SelectedIndex = -1;
            txtmark.Clear();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgvmarks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a record to edit.");
                return;
            }

            if (cobstudent.SelectedIndex == -1 || cobexamname.SelectedIndex == -1)
            {
                MessageBox.Show("Student and Exam are required.");
                return;
            }

            if (!int.TryParse(txtmark.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Invalid score.");
                return;
            }

            Mark mark = new Mark
            {
                StudentId = Convert.ToInt32(cobstudent.SelectedValue),
                ExamTimetableId = Convert.ToInt32(cobexamname.SelectedValue),
                Score = score
            };

            if (Markcontroller.EditMark(mark))
            {
                MessageBox.Show("Updated.");
                LoadMarksGrid();
                ClearForm();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cobstudent.SelectedIndex == -1 || cobexamname.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Student and Exam.");
                return;
            }

            if (!int.TryParse(txtmark.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Score must be between 0 and 100.");
                return;
            }

            Mark newMark = new Mark
            {
                StudentId = Convert.ToInt32(cobstudent.SelectedValue),
                ExamTimetableId = Convert.ToInt32(cobexamname.SelectedValue),
                Score = score
            };

            if (Markcontroller.AddMark(newMark))
            {
                MessageBox.Show("Mark added successfully.");
                LoadMarksGrid();
                ClearForm();
            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {

        }

        private void dgvmarks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvmarks.SelectedRows.Count > 0)
            {
                var row = dgvmarks.SelectedRows[0];

                cobstudent.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value);
                cobexamname.SelectedValue = Convert.ToInt32(row.Cells["ExamTimetableId"].Value);
                cobsubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectId"].Value);
                txtmark.Text = row.Cells["Score"].Value.ToString();
            }
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
