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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernametxt.Text) ||
                string.IsNullOrWhiteSpace(passwordtxt.Text))
            {
                MessageBox.Show("please fill all fields", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            User user = new User
            {
                Username = usernametxt.Text,
                Password = passwordtxt.Text,
            };
            Usercontroller usercontroller = new Usercontroller();
            usercontroller.AddAdmin(user);

            MainForm mainForm = new MainForm(user.Id,user.Role,user.Username,user.Password);
            mainForm.ShowDialog();

            this.Close();
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
            passwordtxt.UseSystemPasswordChar = true;            
        }

        private void showpicbox_Click(object sender, EventArgs e)
        {
            passwordtxt.UseSystemPasswordChar = false;        
        }

        private void hidepicbox_Click(object sender, EventArgs e)
        {
            passwordtxt.UseSystemPasswordChar = true;
            
        }
    }
}
