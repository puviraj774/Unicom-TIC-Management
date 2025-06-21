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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Unicom_TIC_Management.View
{
    public partial class TimetableForm : Form
    {
        private int selectedId;
        private DateTime Date;
        private TimeSpan Time;
        public TimetableForm()
        {
            InitializeComponent();

        }

        private void TimetableForm_Load(object sender, EventArgs e)
        {
            ClearForm();
            LoadLecturer();
            LoadSubject();
            LoadRoom();
            LoadGrid();
            dtpclass.Value = DateTime.Today;
            dtptime.Value = DateTime.Now;
        }
        public void LoadLecturer()
        {
            coblecturer.DataSource = Lecturercontroller.AllLecturer();
            coblecturer.DisplayMember = "Name";
            coblecturer.ValueMember = "ID";
            coblecturer.SelectedIndex = -1;
        }
        public void LoadSubject()
        {
            cobsubject.DataSource = Subjectcontroller.AllSubjects();
            cobsubject.DisplayMember = "Name";
            cobsubject.ValueMember = "ID";
            cobsubject.SelectedIndex = -1;
        }
        public void LoadRoom()
        {
            cobroom.Items.Add("Hall-A");
            cobroom.Items.Add("Hall-B");
            cobroom.Items.Add("Main Lab");
            cobroom.Items.Add("Mini Lab-1");
            cobroom.Items.Add("Mini Lab-2");
            cobroom.SelectedIndex = -1;
        }

        public void LoadGrid()
        {
            dgvtimetable.DataSource = Timetablecontroller.GetAll();
            dgvtimetable.Columns["ID"].Visible = false;
            dgvtimetable.Columns["SubjectID"].Visible = false;
            dgvtimetable.Columns["LecturerID"].Visible = false;
        }
        public void ClearForm()
        {
            coblecturer.SelectedIndex = -1;
            cobsubject.SelectedIndex = -1;
            cobroom.SelectedIndex = -1;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (coblecturer.SelectedIndex == -1||
                cobsubject.SelectedIndex == -1)
            {
                MessageBox.Show("Subject Or Lecturer Cnnot be Empty.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            Timetable timetable = new Timetable
            {
                LecturerId = Convert.ToInt32(coblecturer.SelectedValue),
                SubjectId = Convert.ToInt32(cobsubject.SelectedValue),
                Room = cobroom.Text.Trim(),
                Date = dtpclass.Value.Date, 
                Time = dtptime.Value.TimeOfDay 
            };
            if (Timetablecontroller.Add(timetable, DateTime.Today))
            {
                ClearForm();
                LoadGrid();
            }
        }


        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgvtimetable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a class to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (coblecturer.SelectedIndex == -1 || cobsubject.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cobroom.Text))
            {
                MessageBox.Show("All fields are required (Lecturer, Subject, Room).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvtimetable.SelectedRows[0].Cells["ID"].Value);

            Timetable timetable = new Timetable
            {
                LecturerId = Convert.ToInt32(coblecturer.SelectedValue),
                SubjectId = Convert.ToInt32(cobsubject.SelectedValue),
                Date = dtpclass.Value.Date,
                Time = dtptime.Value.TimeOfDay,
                Room = cobroom.Text.Trim()
            };

            Timetablecontroller.Edit(timetable, id,DateTime.Today);
            ClearForm();
            LoadGrid();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvtimetable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a class to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvtimetable.SelectedRows[0].Cells["ID"].Value);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this class?",
                                                   "Confirm Delete",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Timetablecontroller.Delete(id);
                ClearForm();
                LoadGrid();
            }
        }

        private void dgvtimetable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvtimetable.SelectedRows.Count > 0)
            {
                var row = dgvtimetable.SelectedRows[0];

                cobroom.Text = row.Cells["Room"].Value.ToString();
                cobsubject.SelectedValue = Convert.ToInt32(row.Cells["SubjectId"].Value);
                coblecturer.SelectedValue = Convert.ToInt32(row.Cells["LecturerId"].Value);
                dtpclass.Value = Convert.ToDateTime(row.Cells["Date"].Value);

                // Time is stored as TimeSpan. So use Add(TimeSpan)
                TimeSpan time = TimeSpan.Parse(row.Cells["Time"].Value.ToString());
                dtptime.Value = DateTime.Today.Add(time); // ✅ This is the correct way

                selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
