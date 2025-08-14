using System.ComponentModel.DataAnnotations;

namespace APISchool.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Required]
        public int StudentId { get; set; }

        //Propiedades de navegacion
        public MusicSchool School { get; set; }
        public Students Students { get; set; }
    }
}
