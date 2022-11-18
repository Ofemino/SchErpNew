using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Persistent.DataContext;

public class SchoolErpDbContext : DbContext
{
    public SchoolErpDbContext(DbContextOptions<SchoolErpDbContext> options) : base(options)
    {
    }
}