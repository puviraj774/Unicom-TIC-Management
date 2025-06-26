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

namespace Unicom_TIC_Management.View
{
    public partial class ExamForm : Form
    {
        private int selectedId = -1;
        public ExamForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void AddExamForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
            btndelete.Enabled = false;
        }
        private void LoadGrid()
        {
            dgvexam.DataSource = Examcontroller.GetAll();
            dgvexam.Columns["ID"].Visible = false;
            dgvexam.Columns["Name"].HeaderText = "Exam Name";
            selectedId = -1;
            btndelete.Enabled = false;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtexam.Text))
            {
                MessageBox.Show("Please enter an exam name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Examcontroller.Add(txtexam.Text))
            {
                MessageBox.Show("Exam name added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtexam.Clear();
                LoadGrid();
                ExamTimetableForm examTimetableForm = new ExamTimetableForm();
                examTimetableForm.LoadExamNames();
            }
        }

        private void dgvexam_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvexam.SelectedRows.Count > 0)
            {
                selectedId = Convert.ToInt32(dgvexam.SelectedRows[0].Cells["ID"].Value);
                btndelete.Enabled = true;
                txtexam.Text = dgvexam.SelectedRows[0].Cells["Name"].Value.ToString();

            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select an exam name to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this exam name?",
                                                  "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (Examcontroller.Delete(selectedId))
                {
                    MessageBox.Show("Deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
            }
        }
    }
}
