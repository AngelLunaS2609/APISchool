namespace APISchool.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UniqueCode { get; set; }
        public int IdMusicSchool { get; set; }

        //Propiedad de navegacion
        public MusicSchool MusicSchool { get; set; }

        public IEnumerable<TeacherStudents> TeacherStudents { get; set; }
    }
}
