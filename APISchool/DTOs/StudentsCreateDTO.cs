using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class StudentsCreateDTO
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de naciemiento es requerida")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "La matricula es requerida")]
        public string UniqueCode { get; set; }
    }
}
