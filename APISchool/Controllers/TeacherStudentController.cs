using APISchool.DTOs;
using APISchool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [Route("api/v1/ts")]
    [ApiController]
    public class TeacherStudentController : ControllerBase
    {
        private readonly ITeacherStudentsService _teacherStudentsService;
        public TeacherStudentController (ITeacherStudentsService teacherStudentsService)
        {
            _teacherStudentsService = teacherStudentsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ts = await _teacherStudentsService.GetAllAsync();
            return Ok(ts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ts = await _teacherStudentsService.GetByIdAsync(id);
            if (ts == null)
            {
                return NotFound(new { message = "No se encontro el registro" });
            }
            return Ok(ts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherStudentsCreateDTO teacherStudentsCreateDTO)
        {
            try
            {
                await _teacherStudentsService.AddAsync(teacherStudentsCreateDTO);
                return CreatedAtAction(nameof(GetById), new { id = teacherStudentsCreateDTO.Id }, teacherStudentsCreateDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Hubo un error al crear el registro: {e.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TeacherStudentsCreateDTO teacherStudentsCreateDTO)
        {
            try
            {
                await _teacherStudentsService.UpdateAsync(teacherStudentsCreateDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar el registro: {e.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delate(int id)
        {
            try
            {
                await _teacherStudentsService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
