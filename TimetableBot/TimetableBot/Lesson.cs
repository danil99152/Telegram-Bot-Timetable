using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Lesson
    {
        public virtual long Id { get; set; }
        public virtual string LessonName { get; set; }
        public virtual DateTime WorkStartDate { get; set; }
        public virtual DateTime WorkEndDate { get; set; }
    }
}