using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using DAL;

namespace Scheduler.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult ViewSchedule()
        {
            Dal db = new Dal();
            ViewBag.searchOptions = db.GetScheduleSearchOptions();
            return View();
        }

        public ActionResult ManageSchedule()
        {
            Dal db = new Dal();
            List<SelectListItem> course = new List<SelectListItem>();
            List<SelectListItem> instructor = new List<SelectListItem>();
            List<SelectListItem> rooms = new List<SelectListItem>();
            course.Add(new SelectListItem() { Text = "Select", Value = "Select", Disabled = true });
            instructor.Add(new SelectListItem() { Text = "Select", Value = "Select", Disabled = true });
            rooms.Add(new SelectListItem() { Text = "Select", Value = "Select", Disabled = true });

            Dal db1 = new Dal();
            foreach (Course c in db1.GetCourses())
            {
                course.Add(new SelectListItem() { Text = string.Format("{0}_{1}_{2}", c.Subject, c.CourseId, c.Title), Value = c.CourseId});
            }

            Dal db2 = new Dal();
            foreach (Instructor i in db2.GetInstructors())
            {
                instructor.Add(new SelectListItem() { Text = string.Format("{0} {1} {2}", i.FirstName, i.MiddleName, i.LastName), Value = i.InstructorId.ToString()});
            }

            Dal db3 = new Dal();
            foreach (Rooms r in db3.GetRooms())
            {
                rooms.Add(new SelectListItem() { Text = string.Format("{0}_{1}", r.Building,r.Location), Value = r.RoomNumber.ToString()});
            }

            ViewBag.course = course;
            ViewBag.instructor = instructor;
            ViewBag.rooms = rooms;

            return View();
        }


        public ActionResult ManageInstructor()
        {
            return View();
        }

        public ActionResult ManageCourse()
        {

            Dal db = new Dal();
            List<SelectListItem> subject = new List<SelectListItem>();
            List<SelectListItem> category = new List<SelectListItem>();
            subject.Add(new SelectListItem() { Text = "Select", Value = "Select", Disabled = true });
            category.Add(new SelectListItem() { Text = "Select", Value = "Select", Disabled = true });
           
            foreach (Enums e in db.GetEnums())
            {
                if (e.Type == "Subject")
                {
                    subject.Add(new SelectListItem() { Text = e.Value, Value = e.Value });
                }
                else if (e.Type == "Category")
                {
                    category.Add(new SelectListItem() { Text = e.Value, Value = e.Value });
                }

            }

            ViewBag.subject = subject;
            ViewBag.category = category;
            return View();
        }

       public ActionResult Charts()
        {
            return View();
        }

        public ActionResult ManageClassRoom()
        {
            return View();
        }

    }


}