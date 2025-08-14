namespace APISchool.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UniqueCode { get; set; }

        // Propedades de navegación
        public IEnumerable<TeacherStudents> TeacherStudents { get; set; }
    }
}
