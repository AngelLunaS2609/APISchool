using System.ComponentModel.DataAnnotations;

namespace APISchool.Models
{
    public class TeacherStudents
    {
        public int Id { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int StudentId { get; set; }

        //Propiedades de navegacion
        public Teachers Teacher { get; set; }
        public Students Student { get; set; }
    }
}
