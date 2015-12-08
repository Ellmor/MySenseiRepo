using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySensei.DataContext;
using MySensei.Entities;
using MySensei.Models;

namespace MySensei.Controllers
{

    public class HomeController : Controller
    {
        private MySenseiDb MySenseiDb = new MySenseiDb();
        public ActionResult Index()


        {
            var model = new CourseUserViewModel();

            foreach (Course c in MySenseiDb.Courses.ToList())
            {
                var ftCourse = new FtCourseViewModel()
                {
                    Description = c.Description,
                    Id = c.CourseID,
                    ImageUrl = c.Picture,
                    Price = Convert.ToDecimal(c.Price),
                    Title = c.Title                  

                };
                
                model.addFTCourse(ftCourse);
            }
            
            foreach (User u in MySenseiDb.Users.ToList())
            {
                if (u.OfferedCourses.Count < 10) { 
                var ftTeacher = new FtTeacherViewModel()
                {
                    Description = u.Description,
                    Id = u.UserId,
                    ImageUrl = u.ProfilePicture,
                    name = u.Fullname

                };


                model.addFTTeacher(ftTeacher);
                }

            }
            

            


            return View(model);
        }

    }
}