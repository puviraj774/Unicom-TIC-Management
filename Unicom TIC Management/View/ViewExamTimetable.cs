using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.Controllers;
using Unicom_TIC_Management.Models;
using Unicom_TIC_Management.Repos;

namespace Unicom_TIC_Management.View
{
    public partial class ViewExamTimetable : Form
    {
        public ViewExamTimetable()
        {
            InitializeComponent();
        }

        private void ViewExamTimetable_Load(object sender, EventArgs e)
        {
            LoadGrid();
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
    }
    
}
