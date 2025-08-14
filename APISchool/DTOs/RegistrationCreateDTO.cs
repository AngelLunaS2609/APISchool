using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class RegistrationCreateDTO
    {
        public int Id { get; set; }
        [Display(Name = "Escuela")]
        [Required(ErrorMessage = "La escuela es requerida")]
        public int SchoolId { get; set; }
        [Display(Name = "Estudiante")]
        [Required(ErrorMessage = "El estudiante es requerido")]
        public int StudentId { get; set; }
    }
}
