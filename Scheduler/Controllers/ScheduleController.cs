using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Scheduler.Controllers
{
    public class ScheduleController : Controller
    {
        [HttpPost]
        public ActionResult GetSchedules()
        {
            Dal db = new Dal();
            List<Schedule> schedules = new List<Schedule>();
            schedules = db.GetSchedules();
            return Json(new { data = schedules }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddOrUpdateSchedule(bool isNew,string scheduleId,int CRN,string courseId,string instructorId,int section,string roomNumber,string days,string startDate,string endDate, string startTime, string endTime,int series)
        {
            Dal db = new Dal();

            Schedule schedule = new Schedule();
            schedule.ScheduleId = Convert.ToInt32(scheduleId);
            schedule.CRN = CRN;
            schedule.Course = courseId;
            schedule.Instructor = instructorId;
            schedule.Section = section;
            schedule.location = roomNumber;
            schedule.Days = days;
            schedule.StartDate = startDate;
            schedule.Enddate = endDate;
            schedule.StartTime = startTime;
            schedule.EndTime = endTime;
            schedule.Series = series;

            int result = db.AddOrUpdateSchedule(isNew,schedule);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteSchedule(int scheduleId)
        {
            Dal db = new Dal();
            int result = db.DeleteSchedule(scheduleId);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string GetEvents(string start,string end,string instructorsList,string courseList)
        {
            Dal db = new Dal();
            List<Event> events = new List<Event>();
            List<Schedule> schedules = db.GetSchedules().Where(x=>(instructorsList.IndexOf(x.Instructor.Trim()) > -1 && courseList.IndexOf(x.Title.Trim()) > -1)).ToList<Schedule>();
            foreach ( Schedule S in schedules)
            {
                string startTime = Convert.ToDateTime(S.Time.Substring(0, 8)).ToString("HH:mm:ss");
                string endTime = Convert.ToDateTime(S.Time.Substring(S.Time.IndexOf('-') + 2)).ToString("HH:mm:ss");
                foreach (DateTime D in DateRange(Convert.ToDateTime(S.StartDate), Convert.ToDateTime(S.Enddate),GetDays(S.Days)))
                {
                    Event even = new Event();
                    even.title = string.Join(" ", Regex.Split(S.Subject + " "+S.Course + " By " + S.Instructor + " @ " + S.Building + " " + S.location.ToString(), @"(?:\r\n|\n|\r)"));  ;
                    even.start = D.ToString("yyyy-MM-dd") + 'T' + startTime;
                    even.end =  D.ToString("yyyy-MM-dd") + 'T' +  endTime;
                    even.allDay = "false";
                    events.Add(even);
                }
            }

            Dal db1 = new Dal();

            foreach(Holiday H in db1.GetHolidays())
            {
                Event even1 = new Event();
                even1.title = "Holiday - "+H.Description;
                even1.start = Convert.ToDateTime(H.HolidayDate).ToString("yyyy-MM-dd") + 'T' + "08:00:00";
                even1.end = Convert.ToDateTime(H.HolidayDate).ToString("yyyy-MM-dd") + 'T' + "16:00:00";
                even1.allDay = "true";
                events.Add(even1);
            }

            var json = JsonConvert.SerializeObject(new
            {
                events
            });
            return json;
        }


        public IEnumerable<DateTime> DateRange(DateTime fromDate, DateTime toDate,List<DayOfWeek> days)
        {
            Dal db1 = new Dal();
            IEnumerable<DateTime> daysList=Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1)
                             .Select(d => fromDate.AddDays(d)).Where(x=> days.Contains(x.DayOfWeek) && !db1.GetHolidays().Select(h=>Convert.ToDateTime(h.HolidayDate)).ToList().Contains(x));
            return daysList;
        }

        public List<DayOfWeek> GetDays(string days)
        {
            List<DayOfWeek> daysList = new List<DayOfWeek>();

            if(days == "")
            {
                daysList.Add(DayOfWeek.Monday);
                daysList.Add(DayOfWeek.Tuesday);
                daysList.Add(DayOfWeek.Wednesday);
                daysList.Add(DayOfWeek.Thursday);
                daysList.Add(DayOfWeek.Friday);

                return daysList;
            }

            if(days.Contains("TH"))
            {
                daysList.Add(DayOfWeek.Thursday);
                days.Replace("TH", "");
            }
            if (days.Contains('M'))
                daysList.Add(DayOfWeek.Monday);
            if (days.Contains('T'))
                daysList.Add(DayOfWeek.Tuesday);
            if (days.Contains('W'))
                daysList.Add(DayOfWeek.Wednesday);
            if (days.Contains('F'))
                daysList.Add(DayOfWeek.Friday);

            return daysList;
        }


    }
}
