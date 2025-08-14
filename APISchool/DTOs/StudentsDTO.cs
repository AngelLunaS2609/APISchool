using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class StudentsDTO
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Matricula")]
        public string UniqueCode { get; set; }
    }
}
