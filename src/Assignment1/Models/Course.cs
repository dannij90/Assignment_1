using System;

namespace Assignment1.Models
{
    public class Course
    {
        // The data in my Courses

        public int ID { get; set; }
        public string Name { get; set; }
        public string TemplateID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
