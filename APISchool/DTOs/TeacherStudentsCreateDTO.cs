using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class TeacherStudentsCreateDTO
    {
        public int Id { get; set; }
        [Display(Name = "Profesor")]
        [Required(ErrorMessage = "El profesor es requerido")]
        public int IdTeacher { get; set; }

        [Display(Name = "Estudiante")]
        [Required(ErrorMessage = "El estudiante es requerido")]
        public int IdStudent { get; set; }
        
    }
}
