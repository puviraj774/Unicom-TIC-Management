using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management.Models
{
    internal class LecturerSubject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int LecturerId { get; set; }
        public string LecturerName { get; set; }
    }
}
