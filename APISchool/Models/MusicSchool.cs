namespace APISchool.Models
{
    public class MusicSchool
    {
        public int Id { get; set; }
        public string name {  get; set; }
        public string description { get; set; }
        public string code { get; set; }

        // Propedades de navegación
        public IEnumerable<Teachers> Teachers { get; set; }
    }
}
