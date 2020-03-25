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
        db Db = new db();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] User user)
        {
            int res = Db.LoginCheck(user);
            if (res == 1)
            {
                TempData["msg"] = "Success!";
            }
            else
            {
                TempData["msg"] = "Invalid Data!";
            }
            return View();
        }
        //private readonly ILogger<HomeController> _logger;
        //ModelContext db;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        /*public HomeController(ModelContext context)
        {
            db = context;
        }*/

        /*public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
