﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Classroom
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}