using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Scheduler.Controllers
{
    public class InstructorController : Controller
    {
        [HttpPost]
        public ActionResult GetInstructors()
        {
            Dal db = new Dal();
            List<Instructor> instructors = new List<Instructor>();
            instructors = db.GetInstructors();
            return Json(new { data = instructors }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult AddOrUpdateInstructor(bool isNew,int instructorId , string firstName, string middleName, string lastName, string email)
        {
            Dal db = new Dal();
            int result = db.AddOrUpdateInstructor(isNew, instructorId, firstName, middleName,lastName, email);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteInstructor(int instructorId)
        {
            Dal db = new Dal();
            int result = db.DeleteInstructor(instructorId);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }




    }
}