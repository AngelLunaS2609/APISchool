using APISchool.DTOs;

namespace APISchool.Services
{
    public interface IConsultService
    {
        Task<IEnumerable<StudentForTeacherDTO>> GetStudentsForTeacherAsync(int teacherId);
    }

}

