using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Schedule
    {
        public int ScheduleId { get; set; }

        public int CRN { get; set; }

        public string Subject { get; set; }

        public string Course { get; set; }

        public int Section { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Instructor { get; set; }

        public string Days { get; set; }

        public string Time { get; set; }

        public string StartDate { get; set; }

        public string Enddate { get; set; }

        public string Building { get; set; }

        public string location { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int Series { get; set; }
    }
}
