using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Interfaces;
using Student.Domain.Entities;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _repo.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentModel student)
        {
            await _repo.AddAsync(student);
            return Ok(student);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentModel student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            await _repo.UpdateAsync(student);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();

        }


    }
}
