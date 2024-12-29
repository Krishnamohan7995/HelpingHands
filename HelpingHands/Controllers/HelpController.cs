using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpingHands.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Get()
        {
            Repository s = new Repository();
            ModelState.Clear();
            return View(s.Get());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Users obj)
        {
           Repository s = new Repository();
            if (ModelState.IsValid)
            {
                int i = s.Add(obj);
                if (i == 1)
                {
                    ViewBag.msg = "Inserted";
                    return RedirectToAction("Get");
                }
                else
                {
                    ViewBag.msg = "Failed";
                }
            }
            return View();
        }
        public ActionResult LoginCheck()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(login obj)
        {
            Repository s = new Repository();
            if (ModelState.IsValid)
            {
                if (s.LoginCheck(obj))
                {
                    return RedirectToAction("Home");
                }
                else
                {
                    ViewBag.msg = "Login Failed";
                }
            }
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            Repository s=new Repository();
            return View(s.Get().Find(e =>e.Uid==id));
        }
        [HttpPost]
        public ActionResult Edit(Users obj,int id)
        {
            Repository s = new Repository();
            int i=s.Update(obj);
            if(i == 1)
            {
                return RedirectToAction("Get");
            }
            else
            {
                ViewBag.msg = "update failed";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
           
            if (ModelState.IsValid)
            {
                Repository s = new Repository();
                int i = s.Delete(id);
                if (i == 1)
                {
                    return RedirectToAction("Get");
                }
                else
                {
                    ViewBag.msg = "Delete Failed";
                }
            }
            return View();
        }
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