using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attendance.Models;
using Microsoft.AspNetCore.Identity;
namespace Attendance.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebContext _context;
        UserManager<IdentityUser> _userManager;

        public HomeController(WebContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_context.subjects.Where(x => x.Teacher_id.Equals(_userManager.GetUserId(User))));
        }
        public IActionResult Groups(string lesson)
        {
            TempData["Lesson"] = lesson;
            return View(_context.subjects.Where(x => x.Teacher_id.Equals(_userManager.GetUserId(User)) && x.Lesson.Equals(lesson)));
        }
        public IActionResult StudentsList(string group, string lesson)
        {
            var stud = _context.students.Where(n => n.Group.Equals(group)).Select(x => x.Student_name).ToList();

            return View(_context.attendances
                .Where(x => x.Teacher_id.Equals(_userManager.GetUserId(User))
                && x.Lesson.Equals(lesson)
                && stud.Contains(x.Student_name)
            ));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
