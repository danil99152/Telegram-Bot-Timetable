using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class LessonMap: ClassMap<Lesson>
    {
        public LessonMap()
        {
            Id(l => l.Id).GeneratedBy.Identity();
            Map(l => l.LessonName).Length(30);
            Map(l => l.WorkStartDate);
            Map(l => l.WorkEndDate);
        }
    }
}