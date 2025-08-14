using APISchool.Data;
using APISchool.DTOs;
using EcommerceRestGen7.Constants;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public class StudentService : IStudentService
    {
        //Depending Inyection
        private readonly ApplicationDbContext _context;

        //Constructor
        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<StudentsDTO>> GetAllAsync()
        {
            var student = await _context.Students.Select(s => new StudentsDTO
            {
                Id = s.Id,
                Name = s.Name,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                UniqueCode = s.UniqueCode,
            }).ToListAsync();
            return student;
        }
        public async Task<StudentsDTO> GetByIdAsync(int id)
        {
            var student = await _context.Students.Where(s => s.Id == id).
                Select(s => new StudentsDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    LastName = s.LastName,
                    UniqueCode = s.UniqueCode,
                    BirthDate = s.BirthDate
                }).FirstOrDefaultAsync();

            if (student == null)
                throw new ApplicationException(string.Format(Messages.Error.StudentNotFoundWithId));
            return student;
        }

        public async Task AddAsync(StudentsCreateDTO studentsCreateDTO)
        {
            var student = new Models.Students
            {
                Name = studentsCreateDTO.Name,
                LastName = studentsCreateDTO.LastName,
                UniqueCode = studentsCreateDTO.UniqueCode,
                BirthDate = studentsCreateDTO.BirthDate,
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            studentsCreateDTO.Id = student.Id;
        }
        public async Task UpdateAsync(StudentsCreateDTO studentsCreateDTO)
        {
            var student = await _context.Students.FindAsync(studentsCreateDTO.Id);
            if (student == null)
                throw new ApplicationException(Messages.Error.StudentNotFound);
            student.Name = studentsCreateDTO.Name;
            student.LastName = studentsCreateDTO.LastName;
            student.UniqueCode = studentsCreateDTO.UniqueCode;
            student.BirthDate = studentsCreateDTO.BirthDate;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                throw new ApplicationException(Messages.Error.StudentNotFound);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
