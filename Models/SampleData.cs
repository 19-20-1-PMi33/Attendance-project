using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attendance.Models;
namespace Attendance.Models
{
    public static class SampleData
    {
        public static void Initialize(WebContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
