using APISchool.Data;
using APISchool.DTOs;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public class ConsultService : IConsultService
    {
        private readonly ApplicationDbContext _context;

        public ConsultService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentForTeacherDTO>> GetStudentsForTeacherAsync(int teacherId)
        {
            var resultado = await (from pa in _context.TeacherStudents
                                   join a in _context.Students on pa.Id equals a.Id
                                   join p in _context.Teachers on pa.Id equals p.Id
                                   join e in _context.MusicSchools on p.Id equals e.Id
                                   where p.Id == teacherId
                                   select new StudentForTeacherDTO
                                   {
                                       NameStudent = a.Name,
                                       LastNameStudent = a.LastName,
                                       School = e.Name,
                                       NameTeacher = p.Name
                                   }).ToListAsync();
            return resultado;
        }

    }
}
