using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableBot
{
    public class Group
    {
        public long Id { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
