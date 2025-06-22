using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_TIC_Management.View
{
    public partial class ProfileForm : Form
    {
        private int ID;
        private string _role;
        private string _username;
        private string _password;
        public ProfileForm(int Id, string role, string username, string password)
        {
            InitializeComponent();
            ID = Id;
            _role = role;
            _username = username;
            _password = password;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            if (_role == "Admin")
            {
                labelrole.Text = "Admin";
                labelusername.Text = _username;
                txtpassword.Text = _password;
                txtpassword.UseSystemPasswordChar = true;
            }
            else if (_role == "Lecturer")
            {
                labelrole.Text = "Lecturer";
                labelusername.Text = _username;
                txtpassword.Text = _password;
                txtpassword.UseSystemPasswordChar = true;
            }
            else if (_role == "Staff")
            {
                labelrole.Text = "Staff";
                labelusername.Text = _username;
                txtpassword.Text = _password;
                txtpassword.UseSystemPasswordChar = true;
            }
            else if (_role == "Student")
            {
                labelrole.Text = "Student";
                labelusername.Text = _username;
                txtpassword.Text = _password;
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm(ID, _role, _username, _password);
            passwordForm.ShowDialog();
        }
    }
}
