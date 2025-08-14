using APISchool.DTOs;
using APISchool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [Route("api/v1/registrations")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var record = await _registrationService.GetAllAsync();
            return Ok(record);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _registrationService.GetByIdAsync(id);
            if (record == null)
            {
                return NotFound(new { message = "No se encontro el registro" });
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrationCreateDTO registrationCreateDTO)
        {
            try
            {
                await _registrationService.AddAsync(registrationCreateDTO);
                return CreatedAtAction(nameof(GetById), new { id = registrationCreateDTO.Id }, registrationCreateDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = $"Hubo un error al crear el registro: {e.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] RegistrationCreateDTO registrationCreateDTO)
        {
            try
            {
                await _registrationService.UpdateAsync(registrationCreateDTO);
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
                await _registrationService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
