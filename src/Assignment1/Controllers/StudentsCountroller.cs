using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    

    public class StudentsCountroller : Controller
    {
        // List of students
        private static List<Student> _students;

        // List of students x enrolled in classes y
        private static List<Enrolled> _enrolled;

        [Route("api/courses/{courseId}/students")]
        [HttpGet]
        public List<Student> GetStudents(int courseId)
        {
            if (_students == null)
            {
                // Creating a new list
                _students = new List<Student>
                {
                    new Student
                    {
                        SSN = "0907904479",
                        Name = "Daníel Jóhannsson"
                    },
                    new Student
                    {
                        SSN = "2109883359",
                        Name = "Jónas Arnþór Guðmundsson"
                    },
                    new Student
                    {
                        SSN = "0708903279",
                        Name = "Max Müller"
                    },
                    new Student
                    {
                        SSN = "1212884789",
                        Name = "Sigurvin Frank Garðarsson"
                    },

                };
                
                // New list of student x enrolled in class y
                _enrolled = new List<Enrolled>
                {
                    new Enrolled
                    {
                        StudentSSN = "0907904479", // Daníel Jóhannsson is registered in class with the CourseID = 1 (Web Services)
                        CourseId = 1
                    },
                    new Enrolled
                    {
                        StudentSSN = "2109883359", // Jónas Arnþór Guðmundsson is registered in class with the CourseID = 1 (Web services)
                        CourseId = 1
                    },
                    new Enrolled
                    {
                        StudentSSN = "0708903279", // Max Muller is registered in class with the CourseID = 2 (Algorithms)
                        CourseId = 2
                    },
                    new Enrolled
                    {
                        StudentSSN = "1212884789", // Sigurvin Frank Garðarsson is registerd in class with the CourseID = 2 (Algorithms)
                        CourseId = 2
                    }

                };

            }

            // Matching the students with the courses
            List<Student> result = new List<Student>();

            foreach (Enrolled studentX in _enrolled)
            {
                if (studentX.CourseId == courseId)
                {
                    result.Add(_students.Find(x => x.SSN == studentX.StudentSSN));
                }
            }

            return result;
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetStudent(string id)
        {
            Student result = new Student();
            try
            {
                result = _students.FirstOrDefault(x => x.SSN == id);
            }
            catch (Exception e)
            {
                return NotFound();
            }


            return new ObjectResult(result);


        }
        // creating a new route for adding a student
        [Route("api/courses/{courseId}/addstudent")]
        [HttpPost("{courseId:int}")]
        
        public IActionResult CreateStudent(int courseId, [FromBody]Student item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Enrolled temp = new Enrolled
            {
                StudentSSN = item.SSN,
                CourseId = courseId
            };

            Student temp1 = new Student
            {
                SSN = item.SSN,
                Name = item.Name
            };
            _enrolled.Add(temp);
            _students.Add(temp1);

            return CreatedAtRoute("GetStudent", new { id = item.SSN }, item);
        }

    }


    
}
