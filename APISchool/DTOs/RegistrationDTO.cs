using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        [Display(Name = "Escuela")]
        public int SchoolId { get; set; }
        [Display(Name = "Estudiante")]
        public int StudentId { get; set; }
    }
}
