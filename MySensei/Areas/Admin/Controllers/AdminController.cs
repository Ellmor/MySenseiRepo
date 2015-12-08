using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySensei.Models;
using MySensei.DataContext;

namespace MySensei.Areas.Admin.Controllers
{
    [Authorize]
    
    public class AdminController : Controller
    {
        private MySenseiDb MySenseiDb = new MySenseiDb();
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var model = MySenseiDb.Users.ToList();
            return View(model);
        }

        public ActionResult Courses()
        {
            var model = MySenseiDb.Courses.ToList();
            return View(model);
        }
    }
}