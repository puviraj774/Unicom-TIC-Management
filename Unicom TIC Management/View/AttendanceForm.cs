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
    public partial class AttendanceForm : Form
    {
        public AttendanceForm()
        {
            InitializeComponent();
        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            cobstatus.Items.Add("Present");
            cobstatus.Items.Add("Absent");
            LoadStudents();
            LoadAttendanceGrid();
        }
        public void LoadStudents()
        {
            cobstudent.DataSource = Studentcontroller.GetIdAndNameOnly();
            cobstudent.DisplayMember = "Name";
            cobstudent.ValueMember = "ID";
            cobstudent.SelectedIndex = -1;
        }
        public void LoadAttendanceGrid()
        {
            dgvattendance.DataSource = Attendancecontroller.GetAll();
            dgvattendance.Columns["ID"].Visible = false;
            dgvattendance.Columns["StudentID"].Visible = false;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (cobstudent.SelectedIndex == -1 || string.IsNullOrEmpty(cobstatus.Text))
            {
                MessageBox.Show("Please select a student and status.");
                return;
            }

            var attendance = new Attendence
            {
                StudentId = Convert.ToInt32(cobstudent.SelectedValue),
                Date = dtpdate.Value.Date,
                Status = cobstatus.Text
            };

            if (Attendancecontroller.Add(attendance))
            {
                LoadAttendanceGrid();
            }
        }

        private void dgvattendance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvattendance.SelectedRows.Count > 0)
            {
                var row = dgvattendance.SelectedRows[0];

                cobstudent.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value);
                dtpdate.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                cobstatus.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpdate.Value.Date;
            var validDates = Attendancecontroller.GetValidDatesForAttendance();

            if (!validDates.Contains(selectedDate))
            {
                MessageBox.Show("Selected date is not a valid class or exam day.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvattendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvattendance.SelectedRows[0].Cells["ID"].Value);
            string newStatus = cobstatus.Text.Trim();

            if (newStatus != "Present" && newStatus != "Absent")
            {
                MessageBox.Show("Status must be 'Present' or 'Absent'.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Attendancecontroller.UpdateAttendance(id, newStatus))
            {
                MessageBox.Show("Status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAttendanceGrid();
            }
            else
            {
                MessageBox.Show("Update failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvattendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cobstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cobstudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
