using Carvajal.Prueba.Data.Config;
using Carvajal.Prueba.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Carvajal.Prueba.Data.Context
{
    public class CarvajalContext : DbContext
    {
        public DbSet<User> Persons { get; set; }
        public DbSet<DocumentType> PersonTypes { get; set; }

        public CarvajalContext(DbContextOptions<CarvajalContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DocumentTypeConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}