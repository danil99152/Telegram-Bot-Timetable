using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Lesson
    {
        public long Id { get; set; }
        public string LessonName { get; set; }
        public virtual DateTime WorkStartDate { get; set; }
        public virtual DateTime WorkEndDate { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Classroom> Classrooms { get; set; } 
        public ICollection<Kind> Kinds { get; set; }
        public ICollection<Weekday> Weekdays { get; set; }
    }
}