using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    // The data for enrolled student x in course y
    public class Enrolled
    {
        public string StudentSSN { get; set; }
        public int CourseId { get; set; }
    }
}
