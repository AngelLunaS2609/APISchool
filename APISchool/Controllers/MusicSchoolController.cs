using APISchool.DTOs;
using APISchool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [Route("api/v1/schools")]
    [ApiController]
    public class MusicSchoolController : ControllerBase
    {
        private readonly IMusicSchoolService _musicSchoolService;
        public MusicSchoolController (IMusicSchoolService musicSchoolService)
        {
            _musicSchoolService = musicSchoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var school = await _musicSchoolService.GetAllAsync();
            return Ok(school);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var school = await _musicSchoolService.GetByIdAsync(id);
            if (school == null)
            {
                return NotFound(new { message = "No se encontro la escuela" });
            }
            return Ok(school);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MusicSchoolCreateDTO musicSchoolCreateDTO)
        {
            try
            {
                await _musicSchoolService.AddAsync(musicSchoolCreateDTO);
                return CreatedAtAction(nameof(GetById), new { id = musicSchoolCreateDTO.Id }, musicSchoolCreateDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Hubo un error al crear la escuela: {e.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] MusicSchoolCreateDTO musicSchoolCreateDTO)
        {
            try
            {
                await _musicSchoolService.UpdateAsync(musicSchoolCreateDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar la escuela: {e.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delate(int id)
        {
            try
            {
                await _musicSchoolService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
