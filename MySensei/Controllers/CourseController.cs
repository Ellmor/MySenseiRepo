using Microsoft.AspNet.Identity;
using MySensei.DataContext;
using MySensei.Entities;
using MySensei.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        public ActionResult Join(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = MySenseiDb.Users.Where(x => x.AspNetUserId == userId).FirstOrDefault();
            var c = MySenseiDb.Courses.Where(x => x.CourseID == id).FirstOrDefault();
            if(!user.TakenCourses.Contains(c)) { 
            user.TakenCourses.Add(c);
            MySenseiDb.SaveChanges();
            }
            return RedirectToAction("Details", new { id = id });
        }
        public ActionResult Leave(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = MySenseiDb.Users.Where(x => x.AspNetUserId == userId).FirstOrDefault();
            var c = MySenseiDb.Courses.Where(x => x.CourseID == id).FirstOrDefault();
            if (user.TakenCourses.Contains(c))
            {
                user.TakenCourses.Remove(c);
                MySenseiDb.SaveChanges();
            }
            return RedirectToAction("Details", new { id = id });
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
                     IEnumerable<Course> dbCourses;
                    string dbQuery = "EXEC dbo.spFindCourse @Phrase = '" + model.Query + "'";
                    using (MySenseiDb)
                    {
                        dbCourses = MySenseiDb.Courses.SqlQuery(dbQuery).ToList();
                    }

                    model.Courses = dbCourses;



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

            var fcvm = new FtCourseViewModel
            {         
                Id = course.CourseID,
                Description = course.Description,
                Price = Convert.ToDecimal(course.Price),
                Title = course.Title,
                ImageUrl = course.Picture

        };

            var userId = User.Identity.GetUserId();
            var user = MySenseiDb.Users.Where(x => x.AspNetUserId == userId).FirstOrDefault();
            Boolean isTeacher = false;
            Boolean isStudent = false;

            foreach (User us in course.Owners)
            {
               if(us == user)
                {
                    isTeacher = true;
                    break;
                }
            }
            foreach(User ut in course.Participants)
            {

                if (ut == user)
                {
                    isStudent = true;
                    break;
                }
            }
            var model = new CUViewModel()
            {
                userId = user.UserId,
                isStudent = isStudent,
                isTeacher = isTeacher,
                CourseInView = fcvm

            };

            return View(model);
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