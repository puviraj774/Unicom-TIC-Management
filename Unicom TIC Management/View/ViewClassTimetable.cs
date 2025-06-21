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
    public partial class ViewClassTimetable : Form
    {
        public ViewClassTimetable()
        {
            InitializeComponent();
        }

        private void ViewClassTimetable_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            dgvtimetable.DataSource = Timetablecontroller.GetAll();
            dgvtimetable.Columns["ID"].Visible = false;
            dgvtimetable.Columns["SubjectID"].Visible = false;
            dgvtimetable.Columns["LecturerID"].Visible = false;
        }
    }
}
