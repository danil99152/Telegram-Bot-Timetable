﻿using FluentNHibernate.Mapping;
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
            HasMany(g => g.Students).KeyColumn("Group_GroupName");
            HasManyToMany(g => g.Lessons).Table("Schedule")
                .ParentKeyColumn("Group_GroupName")
                .ChildKeyColumn("Lesson_LessonName");
        }
    }
}
