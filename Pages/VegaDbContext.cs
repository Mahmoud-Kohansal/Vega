using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Persistence
{
    public class VegaDbContext: DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
        public VegaDbContext(DbContextOptions<VegaDbContext> options):base(options)
        {
        }
    }
}