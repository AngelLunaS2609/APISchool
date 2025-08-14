using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class MusicSchoolDTO
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Display(Name = "Matricula")]
        public string Code { get; set; }
    }
}
