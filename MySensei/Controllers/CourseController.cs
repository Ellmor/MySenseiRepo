using MySensei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySensei.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            var model = new ViewCourseViewModel
            {
                Id = id
            };

            return View(model);
        }
    }
}