using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class TeachersCreateDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; }

        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "La matricula es requerida")]
        public string UniqueCode { get; set; }

        [Display(Name = "Escuela")]
        [Required(ErrorMessage = "La escuela es requerida")]
        public int MusicSchoolId { get; set; }
    }
}
