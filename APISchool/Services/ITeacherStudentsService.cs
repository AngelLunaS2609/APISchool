using APISchool.DTOs;

namespace APISchool.Services
{
    public interface ITeacherStudentsService
    {
        Task<List<TeacherStudentsDTO>> GetAllAsync();
        Task<TeacherStudentsDTO> GetByIdAsync(int id);
        Task AddAsync(TeacherStudentsCreateDTO teacherStudentsCreateDTO);
        Task UpdateAsync(TeacherStudentsCreateDTO teacherStudentsCreateDTO);
        Task DeleteAsync(int id);
    }
}
