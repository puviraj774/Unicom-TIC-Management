using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management.Models
{
    internal class Attendence
    {
        public int Id { get; set; }
        public DateTime Date {  get; set; }
        public int StudentId { get; set; }
        public string Studentname { get; set; }
        public string Status { get; set; }
    }
}
