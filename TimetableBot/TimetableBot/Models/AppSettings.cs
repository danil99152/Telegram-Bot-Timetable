using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimetableBot.Models
{
    public class AppSettings
    {
        public static string Url { get; set; } = "http://localhost:1815/{0}";

        public static string Name { get; set; } = "TimetableBot_bot";

        public static string Key { get; set; } = "715240208:AAHS-H8AUdR2Wr4eOm4wdJKPWNle7CI4V1E";
    }
}