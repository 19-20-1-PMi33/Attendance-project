using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Attendance.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Group { get; set; }
        public DateTime Date { get; set; }
        public string Lesson { get; set; }
    }
}
