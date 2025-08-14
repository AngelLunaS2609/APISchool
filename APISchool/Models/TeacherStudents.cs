using System.ComponentModel.DataAnnotations;

namespace APISchool.Models
{
    public class TeacherStudents
    {
        public int Id { get; set; }
        [Required]
        public int IdTeacher { get; set; }
        [Required]
        public int IdStudent { get; set; }

        //Propiedades de navegacion
        public Students Students { get; set; }
        public Teachers Teachers { get; set; }
    }
}
