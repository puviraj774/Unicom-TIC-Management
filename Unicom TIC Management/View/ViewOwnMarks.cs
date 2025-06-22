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
    public partial class ViewOwnMarks : Form
    {
        private int StudentId;
        public ViewOwnMarks(int id)
        {
            InitializeComponent();
            StudentId = id;
        }

        private void ViewOwnMarks_Load(object sender, EventArgs e)
        {
            LoadMarksForStudent();
        }
        private void LoadMarksForStudent()
        {

            var marks = Markcontroller.GetMarksByStudentId(StudentId);

            dgvOwnMarks.DataSource = marks;

            dgvOwnMarks.Columns["Id"].Visible = false;
            dgvOwnMarks.Columns["StudentId"].Visible = false;
            dgvOwnMarks.Columns["ExamTimetableId"].Visible = false;
            dgvOwnMarks.Columns["SubjectId"].Visible = false;

            dgvOwnMarks.Columns["ExamName"].HeaderText = "Exam";
            dgvOwnMarks.Columns["SubjectName"].HeaderText = "Subject";
            dgvOwnMarks.Columns["Score"].HeaderText = "Score";
        }
    }
}

