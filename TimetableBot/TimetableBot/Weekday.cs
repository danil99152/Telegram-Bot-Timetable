using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Weekday
    {
        public long Id { get; set; }
        public DayOfWeek Day { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
