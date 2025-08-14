using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class TeachersDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Display(Name = "Matricula")]
        public string UniqueCode { get; set; }
        [Display(Name = "Escuela")]
        public int MusicSchoolId { get; set; }
        [Display(Name = "Escuela")]
        public string? MusicSchool { get; set; }
    }
}
