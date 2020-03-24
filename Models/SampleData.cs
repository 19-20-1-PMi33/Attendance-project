using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attendance.Models;
namespace Attendance.Models
{
    public static class SampleData
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();
            if (!context.students.Any())
            {
                context.students.AddRange(
                    new Student
                    {
                        Group="PMi-33",
                        Student_name="Victor",
                        Attend="No"
                    },
                    new Student
                    {
                        Group="PMi-33",
                        Student_name="Vlad",
                        Attend="Yes"
                    },
                    new Student
                    {
                        Group="PMi-33",
                        Student_name = "Vova",
                        Attend = "Yes"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
