using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPS.Domain.Entities;

namespace NPS.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<CompanyEntity>
{
    public void Configure(EntityTypeBuilder<CompanyEntity> builder)
    {
        #region Configurations

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired();

        #endregion Configurations

        #region ForeingKey

        builder.HasMany(x => x.Questionnaires)
                    .WithOne(x => x.Company)
                    .HasForeignKey(x => x.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

        #endregion ForeingKey

        #region SeedDatas

        CompanyEntity[] brandSeedDatas = {
               new("Cibergestión", new DateTime(2024, 01, 01)),
          };

        builder.HasData(brandSeedDatas);

        #endregion SeedDatas
    }
}