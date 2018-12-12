using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TimetableBot
{
    public class Student
    {
        public Guid   Id       { get; set; }
        public string FIO      { get; set; }
        public string Phone    { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
