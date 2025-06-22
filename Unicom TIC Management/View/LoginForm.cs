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
    public partial class LoginForm : Form
    {
        public int _UserId;
        public string _Role;
        public LoginForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
        }
       

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passwordtxt.UseSystemPasswordChar = true;
            usernametxt.Focus();

        }

        private void logintxt_Click(object sender, EventArgs e)
        {
            string username = usernametxt.Text.Trim();
            string password = passwordtxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            var user = new Usercontroller().FindUsernamePassword(username, password);
            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    new MainForm(user.Id, user.Role,username,password).ShowDialog();
                    this.Close();
                }
                else if (user.Role == "Student")
                {
                    int studentId = new Studentcontroller().GetStudentIdByUserId(user.Id);
                    new SubMainForm(studentId,user.Id,user.Role, username, password).ShowDialog();
                    this.Close();
                }
                else if (user.Role == "Lecturer")
                {
                    int lecturerId = new Lecturercontroller().GetLecturerIdByUserId(user.Id);
                    new SubMainForm(lecturerId, user.Id, user.Role, username, password).ShowDialog();
                    this.Close();
                }
                else if (user.Role == "Staff")
                {
                    int staffId = new Staffcontroller().GetStaffIdByUserId(user.Id);
                    new SubMainForm(staffId, user.Id, user.Role, username, password).ShowDialog();
                    this.Close();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }

        private void showpicbox_Click(object sender, EventArgs e)
        {
            passwordtxt.UseSystemPasswordChar = false;

        }

        private void hidepicbox_Click(object sender, EventArgs e)
        {
            passwordtxt.UseSystemPasswordChar = true;

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                logintxt_Click(sender, e);
        }
    }
}
