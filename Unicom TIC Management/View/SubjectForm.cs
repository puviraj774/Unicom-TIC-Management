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
using Unicom_TIC_Management.OOP_Concepts;

namespace Unicom_TIC_Management.View
{
    public partial class SubjectForm : Form
    {
        private int SelectedSubjectId;
        public SubjectForm()
        {
            InitializeComponent();
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            LoadToGridview();
        }

        private void LoadToGridview()
        {
            dgvsubject.DataSource = Subjectcontroller.AllSubjects();
            

            this.BeginInvoke(new Action(() =>
            {
                dgvsubject.ClearSelection();
                dgvsubject.CurrentCell = null;
                SelectedSubjectId = -1;
                txtname.Clear();
            }));
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("Subject Name Cannot be Empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Subject subject = new Subject
            {
                Name = txtname.Text
            };
            Subjectcontroller controller = new Subjectcontroller();
            controller.Addsubject(subject);
            
            LoadToGridview();
            txtname.Clear();
        }

        private void dgvsubject_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvsubject.SelectedRows.Count == 0 || dgvsubject.CurrentCell == null)
            {
                SelectedSubjectId = -1;
                txtname.Clear();
                return;
            }

            var row = dgvsubject.SelectedRows[0];
            var courseview = row.DataBoundItem as Subject;

            if (courseview != null)
            {
                SelectedSubjectId = courseview.Id;

                Subjectcontroller controller = new Subjectcontroller();
                var subject = controller.GetSubjectById(courseview.Id);
                if (subject != null)
                {
                    txtname.Text = subject.Name;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtname.Text))
            {
                MessageBox.Show("Select a Subject to delete!", "Error", MessageBoxButtons.OK);
                return;
            }
            var result = MessageBox.Show("Are you sure you want to delete this Subject?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Subjectcontroller controller = new Subjectcontroller();
                controller.DeletesubjectFromSubjects(SelectedSubjectId);
            }

            SelectedSubjectId = -1;
            txtname.Clear();
            LoadToGridview();
        }

        private void linkbtn_Click(object sender, EventArgs e)
        {
            CourseSubjectForm courseSubjectForm = new CourseSubjectForm();
            courseSubjectForm.ShowDialog();

        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
