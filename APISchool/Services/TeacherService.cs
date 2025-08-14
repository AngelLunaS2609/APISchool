using APISchool.Data;
using APISchool.DTOs;
using Azure.Messaging;
using EcommerceRestGen7.Constants;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public class TeacherService : ITeacherService
    {
        //Depending Inyection
        private readonly ApplicationDbContext _context;

        //Constructor
        public TeacherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TeachersDTO>> GetAllAsync()
        {
            var teachers = await _context.Teachers.Select(t => new TeachersDTO
            {
                Id = t.Id,
                Name = t.Name,
                LastName = t.LastName,
                UniqueCode = t.UniqueCode,
                MusicSchoolId = t.MusicSchoolid
            }).ToListAsync();
            return teachers;
        }
        public async Task<TeachersDTO> GetByIdAsync(int id)
        {
            var teacher = await _context.Teachers.Where(t => t.Id == id).
                Select(t => new TeachersDTO
            {
                Id = t.Id,
                Name = t.Name,
                LastName = t.LastName,
                UniqueCode = t.UniqueCode,
                MusicSchoolId = t.MusicSchoolid
            }).FirstOrDefaultAsync();

            if (teacher == null)
                throw new ApplicationException(string.Format(Messages.Error.TeacherNotFoundWithId));
            return teacher;
        }

        public async Task AddAsync(TeachersCreateDTO teachersCreateDTO)
        {
            var teacher = new Models.Teachers
            {
                Name = teachersCreateDTO.Name,
                LastName = teachersCreateDTO.LastName,
                UniqueCode = teachersCreateDTO.UniqueCode,
                MusicSchoolid = teachersCreateDTO.MusicSchoolId
            };
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            teachersCreateDTO.Id = teacher.Id;
        }
        public async Task UpdateAsync(TeachersCreateDTO teachersCreateDTO)
        {
            var teacher = await _context.Teachers.FindAsync(teachersCreateDTO.Id);
            if (teacher == null)
                throw new ApplicationException(Messages.Error.TeacherNotFound);
            teacher.Name = teachersCreateDTO.Name;
            teacher.LastName = teachersCreateDTO.LastName;
            teacher.UniqueCode = teachersCreateDTO.UniqueCode;
            teacher.MusicSchoolid = teachersCreateDTO.MusicSchoolId;

            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if(teacher == null)
                throw new ApplicationException(Messages.Error.TeacherNotFound);

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }



    }
}
