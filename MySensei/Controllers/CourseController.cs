using MySensei.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySensei.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: Course
        [AllowAnonymous]
        public ActionResult Search()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult View(int id)
        {
            var model = new ViewCourseViewModel
            {
                Id = id
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
            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            //    var mysenseiuser = new User
            //    {
            //        Fullname = model.Fullname,
            //        UserName = model.Username,
            //        AspNetUserId = user.Id
            //    };
            //    var result = await UserManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            //        MySenseiDb.Users.Add(mysenseiuser);
            //        MySenseiDb.SaveChanges();
            //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //        // Send an email with this link
            //        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            //        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            //        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            //        return RedirectToAction("Index", "Manage");
            //    }
            //    AddErrors(result);
            //}

            //// If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}