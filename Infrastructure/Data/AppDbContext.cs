using CQRS.Practico.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
