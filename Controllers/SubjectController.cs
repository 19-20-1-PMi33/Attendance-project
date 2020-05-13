using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Attendance.Models;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.Controllers
{
    public class SubjectController : Controller
    {
        ModelContext db;

        public SubjectController(ModelContext context)
        {
            db = context;
        }

        public IActionResult GroupsList(string subject, string groupsList)
        {
            ViewData["Title"] = subject;
            return View(groupsList.Split(", "));
        }
    }
}