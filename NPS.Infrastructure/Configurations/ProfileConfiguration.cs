using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPS.Domain.Entities;

namespace NPS.Infrastructure.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity>
{
    public void Configure(EntityTypeBuilder<ProfileEntity> builder)
    {
        #region Configurations

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(150).IsRequired();

        #endregion Configurations

        #region ForeingKey

        builder.HasMany(x => x.Users)
                    .WithOne(x => x.Profile)
                    .HasForeignKey(x => x.ProfileId)
                    .OnDelete(DeleteBehavior.Restrict);

        #endregion ForeingKey

        #region SeedDatas

        ProfileEntity[] brandSeedDatas = {
               new("Administrador", "Administrador del sitio", new DateTime(2024, 01, 01)) { Id = 1 },
               new("Votante", "Votante en el cuestionario", new DateTime(2024, 01, 01)) { Id = 2 },
          };

        builder.HasData(brandSeedDatas);

        #endregion SeedDatas
    }
}