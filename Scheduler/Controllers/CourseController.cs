using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Scheduler.Controllers
{
    public class CourseController : Controller
    {
        [HttpPost]
        public ActionResult GetCourses()
        {
            Dal db = new Dal();
            List<Course> courses = new List<Course>();
            courses = db.GetCourses();
            return Json(new { data = courses }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddOrUpdateCourse(bool isNew, string courseId, string subject, string category, string title, int minCredits,int maxCredits,bool specialApproval)
        {
            Dal db = new Dal();
            Course course = new Course();
            course.CourseId = courseId;
            course.Subject = subject;
            course.Category = category;
            course.Title = title;
            course.MinCredits = minCredits;
            course.MaxCredits = maxCredits;
            course.SpecialApproval = specialApproval;

            int result = db.AddOrUpdateCourse(isNew, course);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteCourse(int courseId)
        {
            Dal db = new Dal();
            int result = db.DeleteCourse(courseId);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult GetCourseMap()
        //{
        //    Dal db = new Dal();
        //    List<CourseMap> courseMap = new List<CourseMap>();
        //    courseMap = db.GetCourseMap();
        //    return Json(new { data = courseMap }, JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public ActionResult AddCourseMap(int CRN, string courseId, int instructorId, int section)
        //{
        //    Dal db = new Dal();
        //    int result = db.AddCourseMap(CRN, courseId, instructorId, section);
        //    return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        //}

        

        //[HttpPost]
        //public ActionResult DeleteCRN(int CRN)
        //{
        //    Dal db = new Dal();
        //    int result = db.DeleteCRN(CRN);
        //    return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        //}

    }
}