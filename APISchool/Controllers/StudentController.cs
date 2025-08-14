using APISchool.DTOs;
using APISchool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [Route("api/v1/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController (IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var student = await _studentService.GetAllAsync();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound(new { message = "No se encontro el profesor" });
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentsCreateDTO studentsCreateDTO)
        {
            try
            {
                await _studentService.AddAsync(studentsCreateDTO);
                return CreatedAtAction(nameof(GetById), new { id = studentsCreateDTO.Id }, studentsCreateDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Hubo un error al crear el profesor: {e.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] StudentsCreateDTO studentsCreateDTO)
        {
            try
            {
                await _studentService.UpdateAsync(studentsCreateDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar el profesor: {e.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delate(int id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
