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
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSubjects()
        {
            return View(db.subjects);
        }

        //// Useless for now
        //public IActionResult GetGroups(string group)
        //{
        //    var students = db.students.ToList();
        //    IEnumerable<Student> selectedStudents;
        //    selectedStudents = students.Where(x => x.Group == group);
        //    return View(selectedStudents);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
