using APISchool.Models;
using Microsoft.EntityFrameworkCore;

namespace APISchool.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<MusicSchool> MusicSchools { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<TeacherStudents> TeacherStudents { get; set; }
        public DbSet<Registration> Registration { get; set; }
        
    }
}
