using DesafioTotvs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioTotvs.Infrastructure.EntityFramework.Configurations
{
    public class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(x => x.AverageFuelConsumptionCity).HasColumnType("decimal(5, 2)");
            builder.Property(x => x.AverageFuelConsumptionHighway).HasColumnType("decimal(5, 2)");
        }
    }
}