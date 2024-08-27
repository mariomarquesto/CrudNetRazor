using CrudNetRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CrudNetRazor.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        // Otros DbSet<Entities>...
    }
}
