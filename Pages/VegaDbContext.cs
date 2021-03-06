using Microsoft.EntityFrameworkCore;
using Vega.Models;

namespace Vega.Persistence
{
    public class VegaDbContext: DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }
        
        
        public VegaDbContext(DbContextOptions<VegaDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VehicleFeature>().HasKey(vf => new {vf.VehicleId, vf.FeatureId});
        }
    }
}