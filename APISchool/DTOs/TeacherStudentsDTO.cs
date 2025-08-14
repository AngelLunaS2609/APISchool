using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class TeacherStudentsDTO
    {
        public int Id { get; set; }
        [Display(Name = "Profesor")]
        public int TeacherId { get; set; }
        [Display(Name = "Profesor")]
        public int? Teacher { get; set; }
        [Display(Name = "Estudiante")]
        public int StudentId { get; set; }
        [Display(Name = "Estudiante")]
        public int? Student { get; set; }
    }
}
