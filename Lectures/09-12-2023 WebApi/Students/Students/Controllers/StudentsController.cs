using Microsoft.AspNetCore.Mvc;
using Students.Entities;
using Students.Models;
using System.Net;

namespace Students.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        /*
         * This is ABSOLUTELY NOT the way to do this for real.
         * We have a MUCH better way of keeping track of a list once we learn dependency injection.
         */
        private static List<StudentModel> Students = new List<StudentModel>()
        {
            new StudentModel() { FirstName = "Steven", LastName = "Yackel" }
        };

        [HttpGet]
        public StudentsEntity Get()
        {
            return new StudentsEntity { Students = Students.Select(student => new StudentEntity(student)) };
        }


        [HttpGet("{index:int}")]
        public IActionResult GetOne(int index)
        {
            if (index < 0 || index > Students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return Json(new StudentEntity(Students[index]));
        }

        [HttpGet("{index:int}/admin")]
        public IActionResult GetOneAdmin(int index)
        {
            if (index < 0 || index > Students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            return Json(new AdminStudentEntity(Students[index]));
        }

        [HttpPost]
        public IActionResult Post(StudentEntity studentEntity)
        {
            if (studentEntity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            var model = studentEntity.ToModel();
            Students.Add(model);

            return Json(new StudentEntity(model));
        }

        [HttpPut("{index:int}")]
        public IActionResult Put(int index, StudentEntity studentEntity)
        {
            if (index < 0 || index > Students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            if (studentEntity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            Students[index] = studentEntity.ToModel();

            return Json(new StudentEntity(Students[index]));
        }

        [HttpDelete("{index:int}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index > Students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            Students.RemoveAt(index);

            return StatusCode((int) HttpStatusCode.NoContent);
        }

        [HttpPatch("{index:int}")]
        public IActionResult Patch(int index, StudentEntity studentEntity)
        {
            if (index < 0 || index > Students.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            if (studentEntity == null)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            /*
             * NOTE: This patch method does NOT work with the StudentEntity class as it is written now!
             */

            if (!string.IsNullOrWhiteSpace(studentEntity.FirstName))
            {
                Students[index].FirstName = studentEntity.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(studentEntity.LastName))
            {
                Students[index].LastName = studentEntity.LastName;
            }

            return Json(new StudentEntity(Students[index]));
        }
    }
}
