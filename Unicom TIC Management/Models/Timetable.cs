using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicom_TIC_Management.Models;

namespace Unicom_TIC_Management.Models
{
    internal class Timetable
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public string LecturerName {  get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Room { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

    }
}
