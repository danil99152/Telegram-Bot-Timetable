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
            HasManyToMany(l => l.Teachers)
                .ParentKeyColumn("Lesson_id")
                .ChildKeyColumn("Teacher_id");
            HasManyToMany(l =>l.Classrooms)
                .ParentKeyColumn("Lesson_id")
                .ChildKeyColumn("Classroom_id");
            HasManyToMany(l => l.Kinds)
                .ParentKeyColumn("Lesson_id")
                .ChildKeyColumn("Kind_id");
            HasManyToMany(l => l.Weekdays)
                 .ParentKeyColumn("Lesson_id")
                 .ChildKeyColumn("Weekday_id");
        }
    }
}