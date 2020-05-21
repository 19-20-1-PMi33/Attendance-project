using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Attendance.Models
{
    public class Attend
    {
        [Key]
        public int Id { get; set; }
        public string Teacher_id { get; set; }        
        public string Student_name { get; set; }
        public string Lesson { get; set; }
        public DateTime Data { get; set; }
        public bool Presence { get; set; }
    }
}
