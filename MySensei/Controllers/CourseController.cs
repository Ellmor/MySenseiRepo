using Microsoft.AspNet.Identity;
using MySensei.DataContext;
using MySensei.Entities;
using MySensei.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MySensei.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        //Context for User database
        private MySenseiDb MySenseiDb = new MySenseiDb();

        // GET: Courses   AND SEARCH FOR COURSES
        [AllowAnonymous]
        public ActionResult Index(IndexCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    model = new IndexCourseViewModel()
                    {
                        Courses = new List<Course>(),
                        Query = ""
                    };
                }
                if (model.Courses == null)
                {
                    model.Courses = new List<Course>();
                }
                if (model.Query != "")
                {
                    //search -> run the stored procedure
                } 
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var course = MySenseiDb.Courses.Where(x => x.CourseID == id).FirstOrDefault();
            var cvm = new ViewCourseViewModel
            {
                Id = course.CourseID,
                Description = course.Description,
                Price = Convert.ToDecimal(course.Price),
                Title = course.Title,
                ImageUrl = course.Picture
            };
            return View(cvm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCourseViewModel model)
        {
            //var validImageTypes = new string[]
            //{
            //    "image/gif",
            //    "image/jpeg",
            //    "image/pjpeg",
            //    "image/png"
            //};

            //if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            //{
            //    ModelState.AddModelError("ImageUpload", "This field is required");
            //}
            //else
            //if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            //{
            //    ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            //}

            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    Description = model.Description,
                    Title = model.Title,
                    Price = model.Price.ToString(),
                    Location = "Default Location"
                };

                var userId = User.Identity.GetUserId();
                var user = MySenseiDb.Users.Where(x => x.AspNetUserId == userId).FirstOrDefault();

                course.Owners.Add(user);

                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = "~/Uploads";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    course.Picture = imageUrl;
                }

                MySenseiDb.Courses.Add(course);
                MySenseiDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}