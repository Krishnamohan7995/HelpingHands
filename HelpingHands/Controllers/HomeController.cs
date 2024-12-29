using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpingHands.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult check()
        {

            return View();
        }
        public ActionResult Search(string str)
        {
            BloodEntities b = new BloodEntities();
            List<User> users = b.Users.Where(temp => temp.UserName == str).ToList();
            return Json(users, JsonRequestBehavior.AllowGet);


        }
    }
}