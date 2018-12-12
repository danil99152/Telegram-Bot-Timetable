using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class GroupMap: ClassMap<Group>
    {
        public GroupMap()
        {
            Id(g => g.Id).GeneratedBy.Identity();
            Map(g => g.GroupName).Length(30);
            HasManyToMany(g => g.Students)
                .ParentKeyColumn("Group_id")
                .ChildKeyColumn("Student_id");
        }
    }
}
