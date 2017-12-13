using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Course
    {
        public string CourseId { get; set; }

        public string Subject { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public int MinCredits { get; set; }

        public int MaxCredits { get; set; }

        public bool SpecialApproval { get; set; }
    }
}
