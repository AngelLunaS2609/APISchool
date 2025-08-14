using APISchool.Data;
using APISchool.DTOs;
using EcommerceRestGen7.Constants;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Services
{
    public class RegistrationService : IRegistrationService
    {
        //Depending Inyection
        private readonly ApplicationDbContext _context;

        //Constructor
        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<RegistrationDTO>> GetAllAsync()
        {
            var record = await _context.Registration.Select(r => new RegistrationDTO
            {
                Id = r.Id,
                SchoolId = r.SchoolId,
                StudentId = r.StudentId
            }).ToListAsync();
            return record;
        }
        public async Task<RegistrationDTO> GetByIdAsync(int id)
        {
            var record = await _context.Registration.Where(r => r.Id == id).
                Select(r => new RegistrationDTO
                {
                    Id = r.Id,
                    SchoolId = r.SchoolId,
                    StudentId = r.StudentId
                }).FirstOrDefaultAsync();

            if (record == null)
                throw new ApplicationException(string.Format(Messages.Error.RegistrationNotFoundWithId));
            return record;
        }

        public async Task AddAsync(RegistrationCreateDTO registrationCreateDTO)
        {
            var record = new Models.Registration
            {
                SchoolId = registrationCreateDTO.SchoolId,
                StudentId = registrationCreateDTO.StudentId
            };
            await _context.Registration.AddAsync(record);
            await _context.SaveChangesAsync();
            registrationCreateDTO.Id = record.Id;
        }
        public async Task UpdateAsync(RegistrationCreateDTO registrationCreateDTO)
        {
            var record = await _context.Registration.FindAsync(registrationCreateDTO.Id);
            if (record == null)
                throw new ApplicationException(Messages.Error.RegistrationNotFound);
            record.SchoolId = registrationCreateDTO.SchoolId;
            record.StudentId = registrationCreateDTO.StudentId;

            _context.Registration.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _context.Registration.FindAsync(id);

            if (record == null)
                throw new ApplicationException(Messages.Error.RegistrationNotFound);

            _context.Registration.Remove(record);
            await _context.SaveChangesAsync();
        }
    }
}
