using System.ComponentModel.DataAnnotations;

namespace APISchool.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UniqueCode { get; set; }
        [Required]
        public int IdMusicSchool { get; set; }

        //Propiedad de navegacion
        public MusicSchool MusicSchool { get; set; }

        public IEnumerable<TeacherStudents> TeacherStudents { get; set; }
    }
}
