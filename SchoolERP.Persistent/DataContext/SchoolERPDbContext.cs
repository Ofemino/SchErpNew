using Microsoft.EntityFrameworkCore;
using SchoolERP.Domain.Models;

namespace SchoolERP.Persistent.DataContext;

public class SchoolErpDbContext : DbContext
{
    public SchoolErpDbContext(DbContextOptions<SchoolErpDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().HasData(new List<Student>
        {
            new Student
            {
                Id = 1, Gender = "Male", Title = "Master", FirstName = "Olufemi", MiddleName = "Stephen",
                LastName = "Adesanya", CreatedAt = DateTime.Now, CreatedBy = "ofemino",
                DateOfBirth = DateTime.Today.AddYears(-12), UpdatedAt = DateTime.Today, UpdatedBy = "ofemino"
            },
            new Student
            {
                Id = 2, Gender = "Female", Title = "Miss", FirstName = "Olamide", MiddleName = "Janet",
                LastName = "Bassey", CreatedAt = DateTime.Now, CreatedBy = "ofemino",
                DateOfBirth = DateTime.Today.AddYears(-10), UpdatedAt = DateTime.Today, UpdatedBy = "ofemino"
            }
        });

        modelBuilder.Entity<Staff>().HasData(new List<Staff>
        {
            new Staff
            {
                Id = 1, Gender = "Male", Title = "Mr", FirstName = "James", MiddleName = "John",
                LastName = "Bello", CreatedAt = DateTime.Now, CreatedBy = "ofemino",
                DateOfBirth = DateTime.Today.AddYears(-12), UpdatedAt = DateTime.Today, UpdatedBy = "ofemino"
            },
            new Staff
            {
                Id = 1, Gender = "Male", Title = "Ms", FirstName = "Adebola", MiddleName = "Princess",
                LastName = "Ajanaku", CreatedAt = DateTime.Now, CreatedBy = "ofemino",
                DateOfBirth = DateTime.Today.AddYears(-12), UpdatedAt = DateTime.Today, UpdatedBy = "ofemino"
            },
        });
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<ClassHistory> ClassHistories { get; set; }
}