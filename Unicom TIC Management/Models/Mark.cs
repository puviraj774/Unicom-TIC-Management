using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management.Models
{
    internal class Mark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ExamTimetableId { get; set; }  
        public string ExamName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Score { get; set; }
    }
}
