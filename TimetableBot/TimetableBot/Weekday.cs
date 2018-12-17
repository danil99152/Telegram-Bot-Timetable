using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Weekday
    {
        public virtual long Id { get; set; }
        public virtual DayOfWeek Day { get; set; }
    }
}
