﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace zoom_attendance
{
    public class Attendance
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public List<DateTime> AttendedDates { get; set; }
        public String DiscordID { get; set; }
        public Boolean Regular { get; set; }

    }
}
