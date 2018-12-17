using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class WeekdayMap: ClassMap<Weekday>
    {
        public WeekdayMap()
        {
            Id(w => w.Id).GeneratedBy.Identity();
            Map(w => w.Day);
        }
    }
}
