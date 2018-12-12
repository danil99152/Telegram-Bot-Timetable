using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TimetableBot
{
    public class Student: IUser<long>
    {
        public virtual long Id       { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Phone    { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
