using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.Models;
using Students.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IRepository<Student> studentRepository;
        public StudentController(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<ActionResult<Student>> Get()
        {
            IEnumerable<Student> student = await studentRepository.Get();
            return Ok(student);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Student student = await studentRepository.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Post(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            await studentRepository.Post(student);
            await studentRepository.Save();
            return Ok(student);
        }
        [HttpPut("Change")]
        public async Task<IActionResult> Put(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            await studentRepository.Put(student);
            await studentRepository.Save();
            return Ok(student);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            await studentRepository.Delete(id);
            await studentRepository.Save();
            return Ok(studentRepository);
        }
    }
}
