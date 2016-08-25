using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    [Route("api/courses")]
    public class CoursesController : Controller
    {
        /* Note: the variable is static such that the data will persist during the execution
         * of the web service. Data will be lost when the service is restarted (and that is OK for now). */

        private static List<Course> _courses;

        // GET api/courses 
        [HttpGet]
        public List<Course> GetCourses()
        {
            if(_courses == null)
            {
                _courses = new List<Course>
                {
                    new Course
                    {
                        ID = 1,
                        Name = "Web Services",
                        TemplateID = "T-514-VEFT",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(3)
                    },
                    new Course
                    {
                        ID = 2,
                        Name = "Algorithms",
                        TemplateID = "T-301-REIR",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(3)
                    }
                };

            }

            return _courses;
        }

        /* GET api/values/5
        [HttpGet("{id}", Name ="GetCourse")]
        public IActionResult GetById(int id)
        {

        }*/

        // POST api/values
        [HttpPost]
        public IActionResult CreateCourse([FromBody]Course item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _courses.Add(item);

            return CreatedAtRoute("GetCourse", new { id = item.ID }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
