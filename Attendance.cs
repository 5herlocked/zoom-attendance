using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoom_attendance
{
    public class Attendance
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public List<DateTime> AttendedDates { get; set; }
        public Boolean Regular { get; set; }
    }
}
