using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Holiday
    {
        public int HolidayId { get; set; }

        public string HolidayDate { get; set; }

        public string WeekDay { get; set; }

        public string Description { get; set; }

    }
}
