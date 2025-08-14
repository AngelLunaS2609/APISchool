using APISchool.DTOs;

namespace APISchool.Services
{
    public interface IStudentService
    {
        Task<List<StudentsDTO>> GetAllAsync();
        Task<StudentsDTO> GetByIdAsync(int id);
        Task AddAsync(StudentsCreateDTO studentsCreateDTO);
        Task UpdateAsync(StudentsCreateDTO studentsCreateDTO);
        Task DeleteAsync(int id);
    }
}
