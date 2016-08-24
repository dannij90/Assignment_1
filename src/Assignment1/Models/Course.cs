using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Course
    {
        // The data in my Course

        public int ID { get; set; }
        public string Name { get; set; }
        public string TemplateID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
