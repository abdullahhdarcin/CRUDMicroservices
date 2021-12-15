using Microsoft.EntityFrameworkCore;

namespace CRUD.Services.Employee.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Employee> Employees { get; set; }
    }
}
