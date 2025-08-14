using System.ComponentModel.DataAnnotations;

namespace APISchool.DTOs
{
    public class MusicSchoolCreateDTO
    {
        public int? Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Description { get; set; }
        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "La matricula es requerida")]
        public string Code { get; set; }
    }
}
