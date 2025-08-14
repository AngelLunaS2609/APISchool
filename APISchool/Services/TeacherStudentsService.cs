using APISchool.Data;
using APISchool.DTOs;
using EcommerceRestGen7.Constants;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public class TeacherStudentsService : ITeacherStudentsService
    {
        //Depending Inyection
        private readonly ApplicationDbContext _context;

        //Constructor
        public TeacherStudentsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TeacherStudentsDTO>> GetAllAsync()
        {
            var ts = await _context.TeacherStudents.Select(ts => new TeacherStudentsDTO
            {
                Id = ts.Id,
                TeacherId = ts.TeacherId,
                StudentId = ts.StudentId
                
            }).ToListAsync();
            return ts;
        }
        public async Task<TeacherStudentsDTO> GetByIdAsync(int id)
        {
            var ts = await _context.TeacherStudents.Where(ts => ts.Id == id).
                Select(ts => new TeacherStudentsDTO
                {
                    Id = ts.Id,
                    TeacherId = ts.TeacherId,
                    StudentId = ts.StudentId
                }).FirstOrDefaultAsync();

            if (ts == null)
                throw new ApplicationException(string.Format(Messages.Error.TsNotFoundWithId));
            return ts;
        }

        public async Task AddAsync(TeacherStudentsCreateDTO teacherStudentsCreateDTO)
        {
            var ts = new Models.TeacherStudents
            {
                TeacherId = teacherStudentsCreateDTO.TeacherId,
                StudentId = teacherStudentsCreateDTO.StudentId
            };
            await _context.TeacherStudents.AddAsync(ts);
            await _context.SaveChangesAsync();
            teacherStudentsCreateDTO.Id = ts.Id;
        }
        public async Task UpdateAsync(TeacherStudentsCreateDTO teacherStudentsCreateDTO)
        {
            var ts = await _context.TeacherStudents.FindAsync(teacherStudentsCreateDTO.Id);
            if (ts == null)
                throw new ApplicationException(Messages.Error.TsNotFound);
            ts.TeacherId = teacherStudentsCreateDTO.TeacherId;
            ts.StudentId = teacherStudentsCreateDTO.StudentId;

            _context.TeacherStudents.Update(ts);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ts = await _context.TeacherStudents.FindAsync(id);

            if (ts == null)
                throw new ApplicationException(Messages.Error.TsNotFound);

            _context.TeacherStudents.Remove(ts);
            await _context.SaveChangesAsync();
        }
    }
}
