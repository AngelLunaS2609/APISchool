using APISchool.Data;
using APISchool.DTOs;
using EcommerceRestGen7.Constants;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public class MusicSchoolService : IMusicSchoolService
    {
        //Depending Inyection
        private readonly ApplicationDbContext _context;

        //Constructor
        public MusicSchoolService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MusicSchoolDTO>> GetAllAsync()
        {
            var school = await _context.MusicSchools.Select(s => new MusicSchoolDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Code = s.Code
            }).ToListAsync();
            return school;
        }
        public async Task<MusicSchoolDTO> GetByIdAsync(int id)
        {
            var school = await _context.MusicSchools.Where(s => s.Id == id).
                Select(s => new MusicSchoolDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Code = s.Code
                }).FirstOrDefaultAsync();

            if (school == null)
                throw new ApplicationException(string.Format(Messages.Error.SchoolNotFound));
            return school;
        }

        public async Task AddAsync(MusicSchoolCreateDTO musicSchoolCreateDTO)
        {
            var school = new Models.MusicSchool
            {
                Name = musicSchoolCreateDTO.Name,
                Description = musicSchoolCreateDTO.Description,
                Code = musicSchoolCreateDTO.Code
            };
            await _context.MusicSchools.AddAsync(school);
            await _context.SaveChangesAsync();
            musicSchoolCreateDTO.Id = school.Id;
        }
        public async Task UpdateAsync(MusicSchoolCreateDTO musicSchoolCreateDTO)
        {
            var school = await _context.MusicSchools.FindAsync(musicSchoolCreateDTO.Id);
            if (school == null)
                throw new ApplicationException(Messages.Error.SchoolNotFound);
            school.Name = musicSchoolCreateDTO.Name;
            school.Description = musicSchoolCreateDTO.Description;
            school.Code = musicSchoolCreateDTO.Code;

            _context.MusicSchools.Update(school);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var school = await _context.MusicSchools.FindAsync(id);

            if (school == null)
                throw new ApplicationException(Messages.Error.SchoolNotFound);

            _context.MusicSchools.Remove(school);
            await _context.SaveChangesAsync();
        }
    }
}
