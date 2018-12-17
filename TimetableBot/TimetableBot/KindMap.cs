﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class KindMap : ClassMap<Kind>
    {
        public KindMap()
        {
            Id(k => k.Id).GeneratedBy.Identity();
            Map(k => k.KindName).Length(10);
        }
    }
}