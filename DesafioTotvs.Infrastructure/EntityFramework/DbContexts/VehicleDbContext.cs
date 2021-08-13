using System.Threading;
using System.Threading.Tasks;
using DesafioTotvs.Domain.Entities;
using DesafioTotvs.Domain.UnitOfWork;
using DesafioTotvs.Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DesafioTotvs.Infrastructure.EntityFramework.DbContexts
{
    public class VehicleDbContext : DbContext, IUnitOfWork
    {

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public VehicleDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var affectedRows = await SaveChangesAsync(cancellationToken);
            return affectedRows > 0;
        }
    }
}