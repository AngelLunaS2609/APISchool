namespace APISchool.Models
{
    public class TeacherStudents
    {
        public int Id { get; set; }
        public int IdTeacher { get; set; }
        public int IdStudent { get; set; }

        //Propiedades de navegacion
        public Students Students { get; set; }
        public Teachers Teachers { get; set; }
    }
}
