using APISchool.DTOs;
using APISchool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [Route("api/v1/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teacher = await _teacherService.GetAllAsync();
            return Ok(teacher);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teachers = await _teacherService.GetByIdAsync(id);
            if(teachers == null)
            {
                return NotFound(new { message = "No se encontro el profesor"});
            }
           return Ok(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeachersCreateDTO teachersCreateDTO)
        {
            try
            {
                await _teacherService.AddAsync(teachersCreateDTO);
                return CreatedAtAction(nameof(GetById), new { id = teachersCreateDTO.Id }, teachersCreateDTO);
            }
            catch (Exception e) 
            {
                return BadRequest(new { message = $"Hubo un error al crear el profesor: {e.Message}"});
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TeachersCreateDTO teachersCreateDTO)
        {
            try
            {
                await _teacherService.UpdateAsync(teachersCreateDTO);
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
                await _teacherService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
