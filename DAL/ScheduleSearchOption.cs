using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ScheduleSearchOption
    {
        public int InstructorId { get; set; }

        public string Instructor { get; set; }

        public string CourseId { get; set; }

        public string Title { get; set; }

        public string Section { get; set; }
    }
}
