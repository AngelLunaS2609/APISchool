using APISchool.DTOs;

namespace APISchool.Services
{
    public interface ITeacherService
    {
        Task<List<TeachersDTO>> GetAllAsync();
        Task<TeachersDTO> GetByIdAsync(int id);
        Task AddAsync(TeachersCreateDTO teachersCreateDTO);
        Task UpdateAsync(TeachersCreateDTO teachersCreateDTO);
        Task DeleteAsync(int id);
    }
}
