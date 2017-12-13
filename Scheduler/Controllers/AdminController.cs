using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Scheduler.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
      
        // GET: Admin
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Admin
        public ActionResult Users()
        {
            return View();
        }

        // GET: Admin
        public ActionResult Holidays()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetHolidays()
        {
            Dal db = new Dal();
            List<Holiday> holidays = new List<Holiday>();
            holidays = db.GetHolidays();
            return Json(new { data = holidays  }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddOrUpdateHoliday(bool isNew,string holidayDate,string description)
        {
            Dal db = new Dal();
            int result=db.AddOrUpdateHoliday(isNew, holidayDate, description);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteHoliday(string holidayDate)
        {
            Dal db = new Dal();
            int result = db.DeleteHoliday(holidayDate);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetUsers()
        {
            Dal db = new Dal();
            List<Users> users = new List<Users>();
            users = db.GetUsers();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddOrUpdateUser(bool isNew, string userName, string firstName , string lastName, string email, string role, string password)
        {
            Dal db = new Dal();
            int result = db.AddOrUpdateUser(isNew, userName,firstName,lastName,email,role,password.GetSHA256());
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ResetPassword(string userName,string password)
        {
            Dal db = new Dal();
            int result = db.ResetPassword(userName, password.GetSHA256());
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteUser(string userName)
        {
            Dal db = new Dal();
            int result = db.DeleteUser(userName);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }


    }
}