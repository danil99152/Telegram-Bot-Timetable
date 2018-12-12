using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Teacher
    {
        public long Id { get; set; }
        public string TeacherName { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
