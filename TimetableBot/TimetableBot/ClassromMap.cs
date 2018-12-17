using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class ClassroomMap : ClassMap<Classroom>
    {
        public ClassroomMap()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.Number).Length(3);
        }
    }
}