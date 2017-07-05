using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerProject.TblStudents
{
    class TblStudentsDTO
    {
        public int id { get; set; }
        public string studentId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthdate { get; set; }
        public bool sex { get; set; }
        public string majorId { get; set; }
    }
}
