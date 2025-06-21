using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management.Models
{
    internal class Lecturer:Model_Parent
    {
        public string NIC {  get; set; }
        public int UserID { get; set; }
        public string Username {  get; set; }
        public string Password { get; set; }
    }
}
