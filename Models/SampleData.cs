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
            //To test somethings (temporary)
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (!context.students.Any() && !context.subjects.Any())
            {
                for (int i = 1; i < 10; i++)
                {
                    context.subjects.Add(new Subject() { Date = DateTime.Now, Lesson = "aaa", Group = $"gruop{i.ToString()}" });
                }
                for (int i = 1; i < 10; i++)
                {
                    context.students.Add(new Student() { Student_name = i.ToString(), Attend = "true", Group = $"gruop{i.ToString()}" });
                }
            }
            context.SaveChanges();
            //not working well rn
            //if (!context.students.Any())
            //{
            //    context.students.Add(new Student
            //    {
            //        Group = "PMi-33",
            //        Student_name = "Victor",
            //        Attend = "No"
            //    });
            //    context.students.Add(new Student
            //    {
            //        Group = "PMi-33",
            //        Student_name = "Vlad",
            //        Attend = "Yes"
            //    });
            //    context.students.Add(new Student
            //    {
            //        Group = "PMi-33",
            //        Student_name = "Vova",
            //        Attend = "Yes"
            //    });
            //    context.SaveChanges();
            //}
            //if (!context.subjects.Any())
            //{
            //    context.subjects.Add(new Subject
            //    {
            //        Group = "PMi-33",
            //        Date = DateTime.Now,
            //        Lesson = "Math"
            //    });
            //    context.subjects.Add(new Subject
            //    {
            //        Group = "PMi-33",
            //        Date = DateTime.Now,
            //        Lesson = "Mathaa"
            //    });
            //    context.subjects.Add(new Subject
            //    {
            //        Group = "PMi-33",
            //        Date = DateTime.Now,
            //        Lesson = "Mathbbb"
            //    });
            //    context.SaveChanges();
            //}
        }
    }
}
