using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Classroom
    {
        public virtual long Id { get; set; }
        public virtual int Number { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}