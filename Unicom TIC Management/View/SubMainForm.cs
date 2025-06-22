using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_TIC_Management.OOP_Concepts;

namespace Unicom_TIC_Management.View
{
    public partial class SubMainForm : Form
    {
        private int _Id;
        private int _UserID;
        private string _Role;
        private string _Username;
        private string _Password;
        public SubMainForm(int Id,int userid, string role, string username, string password)
        {
            InitializeComponent();
            _Id = Id;
            _UserID = userid;
            _Role = role;
            _Username = username;
            _Password = password;
        }

        private void SubMainForm_Load(object sender, EventArgs e)
        {
            if (_Role == "Student")
            {
                labelhead.Text = "Student Dashboard";
                btnexammanagement.Visible = false;
                btnmarksmanagement.Visible = false;
            }
            else if (_Role == "Lecturer")
            {
                labelhead.Text = "Lecturer Dashboard";
                btnexammanagement.Visible = false;
                btnviewmarks.Visible = false;
            }
            else if (_Role == "Staff")
            {
                labelhead.Text = "Staff Dashboard";
                btnviewmarks.Visible = false;
            }
        }

        private void btnviewexam_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new ViewExamTimetable(), pnlcenter);
        }

        private void btnexammanagement_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new ExamTimetableForm(), pnlcenter);
        }

        private void btnmarksmanagement_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new MarkForm(), pnlcenter);
        }

        private void btnviewclass_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new ViewClassTimetable(), pnlcenter);
        }

        private void btnviewmarks_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new ViewOwnMarks(_Id), pnlcenter);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new ProfileForm(_UserID, _Role, _Username, _Password), pnlcenter);
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure to Logout.", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
