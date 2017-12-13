using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scheduler.Models;
using DAL;
using System.Web.Security;

namespace Scheduler.Controllers
{
    public class AuthorizeController : Controller
    {
     
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Login user, string ReturnUrl = "")
        {
            Dal dataAccess = new Dal();
            List<Users> users = dataAccess.GetUsers();
            if (ModelState.IsValid)
            {
                string hash = user.Password.GetSHA256();
                if (users.Any(x=>x.UserName == user.Username && x.Password == user.Password.GetSHA256()))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    Users U = users.FirstOrDefault(x => x.UserName == user.Username && x.Password == user.Password.GetSHA256());
                    Session["User"] = U.FirstName;
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("ViewSchedule" , "Home");
                }
                // do something.
                ModelState.Remove("Password");
                ModelState.AddModelError("Password", "Invalid UserName/Password");
            }
            return View();
        }

        [HttpGet]
        public ActionResult GetUserName()
        {
            if(String.IsNullOrEmpty(Session["User"].ToString()))
                return RedirectToAction("LogIn", "Authorize");
            return Json(new { result = Session["User"].ToString() }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Authorize");
        }

    }
}