using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Attendance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Attendance.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly WebContext _context;
        UserManager<IdentityUser> _userManager;

        public HomeController(WebContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _appEnvironment = appEnvironment;
        }
        //test
        public IActionResult GetFile()
        {
            // шлях до файлу
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/book.pdf");
            // тип файла - content-type
            string file_type = "application/pdf";
            // імя файла - необовязково
            string file_name = "book.pdf";
            return PhysicalFile(file_path, file_type, file_name);
        }
        public IActionResult Status()
        {
            return StatusCode(400);
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

        [HttpPost]
        public async Task<IActionResult> StudentsList()
        {
            if (ModelState.IsValid)
            {
                List<string> presenceList = new List<string>();
                var itemIdList = Request.Form["item.Id"];
                foreach (var item in itemIdList)
                {
                    presenceList.Add(Request.Form[$"{item}"].ToString());
                }

                for (int i = 0; i < itemIdList.Count(); i++)
                {
                    Attend usr = _context.attendances.Find(Convert.ToInt32(itemIdList[i]));
                    usr.Presence = presenceList[i] == "true" ? true : false;
                    _context.Entry(usr).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

        public IActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubject([Bind("Id,Group,Lesson,Teacher_id")] Subject subject)
        {

            if (ModelState.IsValid)
            {
                subject.Teacher_id = _userManager.GetUserId(User);
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);

        }

        public IActionResult AddStudents(string group)
        {
            TempData["group"] = group;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudents(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Group = TempData["group"].ToString();
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult AddNote(string lesson)
        {
            TempData["lesson"] = lesson;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNote(Attend attend)
        {
            if (ModelState.IsValid)
            {
                attend.Teacher_id = _userManager.GetUserId(User);
                attend.Lesson = TempData["lesson"].ToString();
                string group = _context.students.Where(x => x.Student_name == attend.Student_name).Select(f => f.Group).FirstOrDefault();
                foreach(var i in _context.students.Where(x => x.Group == group&&x.Student_name!=attend.Student_name))
                {
                    Attend attend1 = new Attend();
                    attend1.Lesson = attend.Lesson;
                    attend1.Teacher_id = attend.Teacher_id;
                    attend1.Student_name = i.Student_name;
                    attend1.Data = attend.Data;
                    attend1.Presence = false;
                    _context.attendances.Add(attend1);
                }
                _context.Add(attend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attend);
        }

        public IActionResult EditSubjects(string lesson)
        {

            return View(_context.subjects.Where(x => x.Lesson.Equals(lesson) && x.Teacher_id.Equals(_userManager.GetUserId(User))).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> EditSubjects()
        {
            if (ModelState.IsValid)
            {
                var UserIDArray = Request.Form["item.Id"];
                var UserFirstNameArray = Request.Form["item.Group"];
                var UserLastNameArray = Request.Form["item.Lesson"];

                for (int i = 0; i < UserIDArray.Count(); i++)
                {
                    Subject usr = _context.subjects.Find(Convert.ToInt32(UserIDArray[i]));
                    usr.Group = UserFirstNameArray[i];
                    usr.Lesson = UserLastNameArray[i];
                    _context.Entry(usr).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


        public IActionResult EditStudents(string group)
        {

            return View(_context.students.Where(x => x.Group == group).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> EditStudents()
        {
            if (ModelState.IsValid)
            {
                var UserIDArray = Request.Form["item.Id"];
                var UserFirstNameArray = Request.Form["item.Group"];
                var UserLastNameArray = Request.Form["item.Student_name"];

                for (int i = 0; i < UserIDArray.Count(); i++)
                {
                    Student usr = _context.students.Find(Convert.ToInt32(UserIDArray[i]));
                    usr.Group = UserFirstNameArray[i];
                    usr.Student_name = UserLastNameArray[i];
                    _context.Entry(usr).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }


        //public IActionResult DeleteSubject(string lesson)
        //{
        //    TempData["lesson"] = lesson;
        //    return RedirectToAction(nameof(Index));
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteSubject()
        //{
        //    var les = _context.subjects.Find("German");
        //    _context.subjects.Remove(les);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
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
