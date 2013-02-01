using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninja.WebSite.Models;
using MongoDB.Driver.Linq;

namespace Ninja.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            using (var userContext = new UsersContext()) {
                var sss = userContext.UserProfiles.AsQueryable().Take(10);
                ViewBag.S = sss;
            }
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your app description page.";
            using (var userContext = new UsersContext()) {
                var newUser = new UserProfile {
                    UserName = Guid.NewGuid().ToString()
                };
                userContext.UserProfiles.Insert(newUser);
            }
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
