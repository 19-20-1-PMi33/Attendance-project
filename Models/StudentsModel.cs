using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendance.Models
{
    public class StudentsModel
    {
        public Student student { get; set; }
        public IEnumerable<Student>students { get; set; }
    }
}

