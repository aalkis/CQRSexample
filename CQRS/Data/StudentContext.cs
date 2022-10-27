using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new(){Id=1, Name="Alper", Surname="Alkis", Age=30},
                new(){Id=2, Name="Serdar", Surname="Alkis", Age=38}
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}
