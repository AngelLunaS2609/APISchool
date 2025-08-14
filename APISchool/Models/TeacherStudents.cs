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
        public Students Students { get; set; }
        public Teachers Teachers { get; set; }
    }
}
