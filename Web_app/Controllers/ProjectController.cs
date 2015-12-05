using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_app.Controllers
{
    public class ProjectController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Input()
        {
            ViewData["Message"] = "Input";

            return View();
        }

        public IActionResult Options()
        {
            ViewData["Message"] = "Options";

            return View();
        }

        public IActionResult Result()
        {
            ViewData["Message"] = "Result";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
