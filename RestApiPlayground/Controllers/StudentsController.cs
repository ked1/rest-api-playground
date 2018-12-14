using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestApiPlayground.Services;

namespace RestApiPlayground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentRepository _inMemoryStudents;
        public StudentsController(IStudentRepository studentRepository)
        {
            _inMemoryStudents = studentRepository;
        }

        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _inMemoryStudents.GetAll(); 
        }

        // GET api/students/1
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            return _inMemoryStudents.Get(id);
        }

        // POST api/student
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _inMemoryStudents.Add(student);
        }

        // PUT api/student/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student editedStudent)
        {
            var student = _inMemoryStudents.Update(editedStudent);
            student.Firstname = editedStudent.Firstname;
            student.Lastname = editedStudent.Lastname;
            student.special = editedStudent.special;
        }

        // DELETE api/student/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _inMemoryStudents.Remove(id);
        }
    }
}
