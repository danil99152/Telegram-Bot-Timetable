using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class TeacherMap: ClassMap<Teacher>
    {
        public TeacherMap()
        {
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.TeacherName).Length(30);
            HasManyToMany(t => t.Lessons)
               .ParentKeyColumn("Teacher_id")
               .ChildKeyColumn("Lesson_id");
        }
    }
}
