using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Data.Models;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

            //NOTE: Merren te gjithe studentet nga databaza
            var allStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Student 1",
                    LastName = "Student 1",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    GraduationYear = 2023,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = null,
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Student 2",
                    LastName = "Student 2",
                    DateOfBirth = DateTime.Now.AddYears(-21),
                    GraduationYear = 2023,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = null,
                }
            };
            return Ok(allStudents);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //NOTE: Merret vetem nje student nga databaza me id
            var student = new Student()
            {
                Id = 1,
                FirstName = "Alijandro",
                LastName = "Firanj",
                GraduationYear = 2023,
                IsActive = true,
                DateOfBirth = DateTime.Now.AddYears(-20),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddSTudent([FromBody] StudentVM studentVM)
        {
            //Krijohet objekti shkolle
            var student = new Student()
            {
                //Id = Gjenerohet nga database
                FirstName = studentVM.FirstName,
                LastName = studentVM.LastName,
                GraduationYear = studentVM.GraduationYear,
                IsActive = studentVM.IsActive,
                DateOfBirth= studentVM.DateOfBirth,

                //Mund te jene edhe ne nivel database
                DateCreated = DateTime.UtcNow,
                DateUpdated = null
            };

            //Objekti i krijuar shtohet ne databaze me Entity Framework
            return Created("", student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] StudentVM studentVM, int id)
        {
            //Merret objekti Student nga database duket perdorur Id si parameter
            var student = new Student()
            {
                Id = 1,
                FirstName = "Student",
                LastName = "Student",
                GraduationYear = "2022"
                IsActive = false,
                DateOfBirth = DateTime.Now.AddYears(-20),
            };


            //Modifikohet objekti Student i marre nga databaza duket perdorur te dhenat nga FromBody
            student.FirstName = studentVM.FirstName;
            student.LastName = studentVM.LastName;
            student.GraduationYear = studentVM.GraduationYear;
            student.IsActive = studentVM.IsActive;
            student.DateOfBirth = DateTime.UtcNow;

            //Perditesohet objekti student ne database me Entity Framework

            return Ok($"Student with id = {id} was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            //NOTE: Kalohet Id si parameter dhe fshihet Student nga databaza

            return Ok($"Student with id {id} deleted");
        }



    }

}
