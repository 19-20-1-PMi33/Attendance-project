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
        ModelContext db;

        public HomeController(ModelContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.subjects);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
