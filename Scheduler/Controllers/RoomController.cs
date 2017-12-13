using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Scheduler.Controllers
{
    public class RoomController : Controller
    {
        [HttpPost]
        public ActionResult GetRooms()
        {
            Dal db = new Dal();
            List<Rooms> rooms = new List<Rooms>();
            rooms = db.GetRooms();
            return Json(new { data = rooms }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult AddOrUpdateRoom(bool isNew, int roomNumber, string building, string location, int capacity)
        {
            Dal db = new Dal();
            Rooms room = new Rooms();
            room.RoomNumber = roomNumber;
            room.Building = building;
            room.Location = location;
            room.Capacity = capacity;
            int result = db.AddOrUpdateRoom(isNew, room);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteRoom(int roomNumber)
        {
            Dal db = new Dal();
            int result = db.DeleteRoom(roomNumber);
            return Json(new { result = result.ToString() }, JsonRequestBehavior.AllowGet);
        }





    }
}