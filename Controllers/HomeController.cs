using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attendance.Models;

namespace Attendance.Controllers
{
    public class HomeController : Controller
    {
        public ModelContext db;

        public HomeController(ModelContext context)
        {
            db = context;
            if (!context.students.Any() && !context.subjects.Any())
                SampleData.Initialize(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSubjects()
        {
            return View(db.subjects);
        }

        public IActionResult GetStudents()
        {
            return View(db.students);
        }

        //Logic to be updated
        public IActionResult GetGroups(string group = "gruop1")
        {
            var students = db.students.ToList();
            IEnumerable<Student> selectedStudents;
            var a = group;
            try
            {
                selectedStudents = students.Where(x => x.Group == "gruop2");
            }
            catch
            {
                selectedStudents = students.Where(x => x.Group == "gruop3");
            }
            return View(selectedStudents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
