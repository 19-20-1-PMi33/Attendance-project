using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Attendance.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Group { get; set; }
        public string Student_name { get; set; }
    }
}
