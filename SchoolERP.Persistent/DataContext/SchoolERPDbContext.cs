using Microsoft.EntityFrameworkCore;
using SchoolERP.Domain.Models;

namespace SchoolERP.Persistent.DataContext;

public class SchoolErpDbContext : DbContext
{
    public SchoolErpDbContext(DbContextOptions<SchoolErpDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Parent> Parents { get; set; }
}