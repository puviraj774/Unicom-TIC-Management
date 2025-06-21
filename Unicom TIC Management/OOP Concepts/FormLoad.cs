using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unicom_TIC_Management.OOP_Concepts
{
    public static class FormLoad
    {
        public static void LoadIntoPanel(Form targetForm, Panel panel)
        {
            panel.Controls.Clear();
            targetForm.TopLevel = false;
            targetForm.FormBorderStyle = FormBorderStyle.None;
            targetForm.Dock = DockStyle.Fill;
            panel.Controls.Add(targetForm);
            targetForm.Show();
        }
    }
}
