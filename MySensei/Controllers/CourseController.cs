using Microsoft.AspNet.Identity;
using MySensei.DataContext;
using MySensei.Entities;
using MySensei.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }
        // GET: Courses   AND SEARCH FOR COURSES
        [AllowAnonymous]
        public ActionResult Search(SearchCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    model = new SearchCourseViewModel()
                    {
                        Courses = new List<Course>(),
                        Query = ""
                    };
                }
                if (model.Courses == null)
                {
                    model.Courses = new List<Course>();
                }
                if (model.Query != null && model.Query != "")
                {
                   //TODO
                    
                    
                    //search -> run the stored procedure
                    //filter or whatever magic
                }
                else
                {
                    //display all courses
                    model.Courses = MySenseiDb.Courses.ToList();
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
           
          
            var validImageTypes = new string[]
            {
              "image/jpeg"
            };
            if (model.ImageUpload == null)
            {
                Debug.WriteLine(model.ImageUpload.ContentLength);
                ModelState.AddModelError("ImageUpload", "This field is requireder");
                
            }  else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

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

                
                    byte[] imgBuffer = null;
                    using (var binaryReader = new BinaryReader(model.ImageUpload.InputStream))
                    {
                        imgBuffer = binaryReader.ReadBytes(model.ImageUpload.ContentLength);
                    }
                    course.Picture = imgBuffer;
                 

                MySenseiDb.Courses.Add(course);
                MySenseiDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}