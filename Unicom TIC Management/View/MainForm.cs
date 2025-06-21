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
    public partial class MainForm : Form
    {
        private int _userId;
        private string _role;
        private string _username;
        private string _password;
        public MainForm(int userId, string role,string Username,string password)
        {
            InitializeComponent();
            _userId = userId;
            _role = role;
            _username = Username;
            _password = password;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {           
            dashboardlabel.Text = "Admin Dashboard";
        }
        private void profilebtn_Click(object sender, EventArgs e)
        {

        }

        private void coursemanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new CourseForm(),mainpanel);
        }

        private void subjectmanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new SubjectForm(), mainpanel);
        }

        private void lecmanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new LecturerForm(), mainpanel);
        }

        private void staffmanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new StaffForm(), mainpanel);
        }

        private void stumanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new StudentForm(), mainpanel);
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure to Logout.","Confirm Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void exammanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new ExamTimetableForm(), mainpanel);
        }

        private void timetablemanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new TimetableForm(), mainpanel);
        }

        private void marksmanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new MarkForm(), mainpanel);
        }

        private void attendencemanagementbtn_Click(object sender, EventArgs e)
        {
            FormLoad.LoadIntoPanel(new AttendanceForm(), mainpanel);
        }
    }
}
