using System.ComponentModel.DataAnnotations;

namespace APISchool.Models
{
    public class MusicSchool
    {
        public int Id { get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }

        // Propedades de navegación
        public IEnumerable<Teachers> Teachers { get; set; }
    }
}
