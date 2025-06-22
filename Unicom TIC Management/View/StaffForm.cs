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
    public partial class StaffForm : Form
    {
        private int selectedStaffId = -1;
        private int selectedUserId = -1;
        public StaffForm()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            txtname.Clear();
            txtnic.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            selectedStaffId = -1;
            selectedUserId = -1;
        }
        private void LoadGrid()
        {
            dgvstaff.DataSource = Staffcontroller.AllStaff()
                .Select(s => new { s.Id, s.Name, s.NIC })
                .ToList();

            dgvstaff.ClearSelection();
            dgvstaff.CurrentCell = null;
        }
        private void dgvstaff_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvstaff.SelectedRows.Count == 0) return;

            var selected = dgvstaff.SelectedRows[0];
            int staffId = (int)selected.Cells["Id"].Value;

            var staff = Staffcontroller.AllStaff().FirstOrDefault(s => s.Id == staffId);
            if (staff != null)
            {
                selectedStaffId = staff.Id;
                selectedUserId = staff.UserID;
                txtname.Text = staff.Name;
                txtnic.Text = staff.NIC;
                txtusername.Text = staff.Username;
                txtpassword.Text = staff.Password;
            }
        }

        private bool IsValidNIC(string nic)
        {
            nic = nic.Trim();

            var oldNicPattern = @"^\d{9}[vVxX]$";
            var newNicPattern = @"^\d{12}$";

            return System.Text.RegularExpressions.Regex.IsMatch(nic, oldNicPattern)||
                   System.Text.RegularExpressions.Regex.IsMatch(nic, newNicPattern);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (Usercontroller.IsNICUsed(txtnic.Text))
            {
                MessageBox.Show("NIC already exists in system.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtnic.Text) ||
                string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (!IsValidNIC(txtnic.Text))
            {
                MessageBox.Show("Invalid NIC number. Please enter a valid NIC.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var staff = new Staff
            {
                Name = txtname.Text.Trim(),
                NIC = txtnic.Text.Trim(),
                Username = txtusername.Text.Trim(),
                Password = txtpassword.Text.Trim()
            };

            new Staffcontroller().AddStaff(staff);
            LoadGrid();
            ClearForm();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
            ClearForm();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedStaffId == -1)
            {
                MessageBox.Show("Please select a staff to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtnic.Text) ||
                string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text) )
                
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this staff?",
                                          "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Staffcontroller controller = new Staffcontroller();
                bool success = controller.DeleteStaff(selectedStaffId);

                if (success)
                {
                    selectedStaffId = -1;
                    ClearForm(); 
                    LoadGrid();
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (Usercontroller.IsNICUsedByOthers(txtnic.Text.Trim(), "Staff", selectedStaffId))
            {
                MessageBox.Show("NIC already exists in system.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtnic.Text) ||
                string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Incomplete Details To Update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!IsValidNIC(txtnic.Text))
            {
                MessageBox.Show("Invalid NIC number. Please enter a valid NIC.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var staff = new Staff
            {
                Id = selectedStaffId,
                UserID = selectedUserId,
                Name = txtname.Text.Trim(),
                NIC = txtnic.Text.Trim(),
                Username = txtusername.Text.Trim(),
                Password = txtpassword.Text.Trim()
            };
            

            new Staffcontroller().UpdateStaff(staff);
            LoadGrid();
            ClearForm();
        }

        private void backpicbox_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
