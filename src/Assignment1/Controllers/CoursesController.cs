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

        //GET api/courses/5 should give me status 404 not found
        [HttpGet("{id:int}", Name ="GetCourse")]
        public IActionResult GetByID(int id)
        {
            Course course = _courses.FirstOrDefault(x => x.ID == id);

            // If no item matches the requested ID, the method returns a 404 error. This is done by returning NotFound();
            if(course == null)
            {
                return NotFound();
            }

            // Otherwise, the method returns 200 OK with a JSON response body. This is done by returning an ObjectResult();
            return new ObjectResult(course);
        }
 
        // POST api/courses
        [HttpPost]
        public IActionResult CreateCourse([FromBody]Course item)
        {
            // if item == null then we return status 400: Bad Request
            if (item == null)
            {
                return BadRequest();
            }
            // Else we add the item to the list of courses
            _courses.Add(item);

            // The CreatedAtRoute method returns a 201: created response
            return CreatedAtRoute("GetCourse", new { id = item.ID }, item);
        }

        // PUT api/courses/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody]Course item)
        {
            if(item == null || item.ID != id)
            {
                // returns 400 Bad Request
                return BadRequest();
            }
            // Find the course with the requested ID
            var index = _courses.FindIndex(x => x.ID == item.ID);

            // If the course ID is not found we return status 404: NotFound();
            if (index == -1)
            {
                return NotFound();
            }

            _courses[index] = item;
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Course course = _courses.FirstOrDefault(x => x.ID == id);
            if(course == null)
            {
                // Returns 404 not found
                return NotFound();
            }

            _courses.Remove(course);

            return new NoContentResult();
         
        }
    }
}
