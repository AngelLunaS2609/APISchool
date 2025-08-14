using APISchool.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISchool.Controllers
{
    [Route("api/v1/consultST")]
    [ApiController]
    public class ConsultStudentTeacherController : ControllerBase
    {
        private readonly IConsultService _consultService;

        public ConsultStudentTeacherController(IConsultService consultService)
        {
            _consultService = consultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentForTeacher(int teacherId)
        {
            var resultado = await _consultService.GetStudentsForTeacherAsync(teacherId);
            return Ok(resultado);
        }

    }
}
