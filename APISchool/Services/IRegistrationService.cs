using APISchool.DTOs;

namespace APISchool.Services
{
    public interface IRegistrationService
    {
        Task<List<RegistrationDTO>> GetAllAsync();
        Task<RegistrationDTO> GetByIdAsync(int id);
        Task AddAsync(RegistrationCreateDTO registrationCreateDTO);
        Task UpdateAsync(RegistrationCreateDTO registrationCreateDTO);
        Task DeleteAsync(int id);
    }
}
