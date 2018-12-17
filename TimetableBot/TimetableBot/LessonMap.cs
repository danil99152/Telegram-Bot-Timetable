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
            HasManyToMany(l => l.Weekdays).Table("Schedule")
                 .ParentKeyColumn("Lesson_LessonName")
                 .ChildKeyColumn("Weekday_Day");
            HasManyToMany(l => l.Teachers).Table("Schedule")
                .ParentKeyColumn("Lesson_LessonName")
                .ChildKeyColumn("Teacher_TeacherName");
            HasManyToMany(l => l.Classrooms).Table("Schedule")
                .ParentKeyColumn("Lesson_LessonName")
                .ChildKeyColumn("Classroom_Number");
            HasManyToMany(l => l.Kinds).Table("Schedule")
                .ParentKeyColumn("Lesson_LessonName")
                .ChildKeyColumn("Kind_KindName");
            // HasManyToMany(l => l.Groups)
            //   .ParentKeyColumn("Lesson_id")
            // .ChildKeyColumn("Group_id");
        }
    }
}