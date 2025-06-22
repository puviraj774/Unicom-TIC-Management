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
    public partial class PasswordForm : Form
    {
        private int _userId;
        private string _role;
        private string _username;
        private string _password;
        public PasswordForm(int userId, string role, string username, string password)
        {
            InitializeComponent();
            _userId = userId;
            _role = role;
            _username = username;
            _password = password;
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtold.Text) || string.IsNullOrWhiteSpace(txtnew.Text) || string.IsNullOrWhiteSpace(txtconfirm.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtold.Text == txtnew.Text)
            {
                MessageBox.Show("New password cannot be the same as old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtold.Text != _password)
            {
                MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtold.Text == _password)
            {
                if (txtnew.Text == txtconfirm.Text)
                {
                    Usercontroller.ChangePassword(_userId, txtnew.Text);
                    MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("New password and confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
