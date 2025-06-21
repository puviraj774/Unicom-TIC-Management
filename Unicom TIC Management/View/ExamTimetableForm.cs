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
    public partial class ExamTimetableForm : Form
    {
        DateTime selectedDate;
        private int selectedid;
        public ExamTimetableForm()
        {
            InitializeComponent();
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            LoadExamNames();
            LoadSubjects();
            LoadGrid();
            ClearForm();
        }
        private void LoadExamNames()
        {
            cobexam.DataSource = Examcontroller.GetAll();
            cobexam.DisplayMember = "Name";
            cobexam.ValueMember = "ID";
            cobexam.SelectedIndex = -1;
        }

        private void LoadSubjects()
        {
            cobsubject.DataSource = Subjectcontroller.GetIdAndNameOnly();
            cobsubject.DisplayMember = "Name";
            cobsubject.ValueMember = "ID";
            cobsubject.SelectedIndex = -1;
        }

        private void LoadGrid()
        {
            dgvexam.DataSource = ExamTimetablecontroller.GetAll();
            dgvexam.Columns["Id"].Visible = false;
            dgvexam.Columns["ExamId"].Visible = false;
            dgvexam.Columns["SubjectId"].Visible = false;
            dgvexam.Columns["ExamName"].HeaderText = "Exam";
            dgvexam.Columns["SubjectName"].HeaderText = "Subject";
            dgvexam.Columns["Date"].HeaderText = "Date";
            dgvexam.Columns["Time"].HeaderText = "Time";
        }

        private void ClearForm()
        {
            cobexam.SelectedIndex = -1;
            cobsubject.SelectedIndex = -1;
            dtpexam.Value = DateTime.Today;
            dtptime.Value = DateTime.Now;
            selectedid = -1;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cobexam.SelectedIndex == -1 || cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Exam and subject must be selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExamTimetable et = new ExamTimetable
            {
                ExamId = Convert.ToInt32(cobexam.SelectedValue),
                SubjectId = Convert.ToInt32(cobsubject.SelectedValue),
                Date = dtpexam.Value.Date,
                Time = dtptime.Value.TimeOfDay
            };

            if (ExamTimetablecontroller.Add(et))
            {
                MessageBox.Show("Added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadGrid();
            }
        }
        private void dgvexam_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvexam.SelectedRows.Count > 0)
            {
                var row = dgvexam.SelectedRows[0];
                cobexam.SelectedValue = Convert.ToInt32(row.Cells["ExamId"].Value);
                cobsubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectId"].Value);
                dtpexam.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                dtptime.Value = DateTime.Today.Add(TimeSpan.Parse(row.Cells["Time"].Value.ToString()));

                selectedid = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (selectedid == -1)
            {
                MessageBox.Show("Select a record to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExamTimetable exam = new ExamTimetable
            {
                ExamId = Convert.ToInt32(cobexam.SelectedValue),
                SubjectId = Convert.ToInt32(cobsubject.SelectedValue),
                Date = dtpexam.Value.Date,
                Time = dtptime.Value.TimeOfDay
            };

            if (ExamTimetablecontroller.Edit(exam, selectedid))
            {
                LoadGrid();
                ClearForm();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedid == -1)
            {
                MessageBox.Show("Select a record to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (ExamTimetablecontroller.Delete(selectedid))
                {
                    LoadGrid();
                    ClearForm();
                }
            }
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnaddexam_Click(object sender, EventArgs e)
        {
            ExamForm addExamForm = new ExamForm();
            addExamForm.ShowDialog();
        }
    }
}
