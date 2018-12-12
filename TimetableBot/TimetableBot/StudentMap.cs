using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(s => s.Id).GeneratedBy.Identity();
            Map(s => s.UserName).Length(30);
            Map(s => s.Phone).Length(11);
            HasManyToMany(s => s.Groups)
                .ParentKeyColumn("Student_id")
                .ChildKeyColumn("Group_id");
        }
    }
}