using APISchool.DTOs;

namespace APISchool.Services
{
    public interface IMusicSchoolService
    {
        Task<List<MusicSchoolDTO>> GetAllAsync();
        Task<MusicSchoolDTO> GetByIdAsync(int id);
        Task AddAsync(MusicSchoolCreateDTO musicSchoolCreateDTO);
        Task UpdateAsync(MusicSchoolCreateDTO musicSchoolCreateDTO);
        Task DeleteAsync(int id);
    }
}
