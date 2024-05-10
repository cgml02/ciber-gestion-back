using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPS.Domain.Entities;

namespace NPS.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        #region Configurations

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();

        #endregion Configurations

        #region ForeingKey

        builder.HasMany(x => x.UserQuestionnaires)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        #endregion ForeingKey

        #region SeedDatas

        UserEntity[] brandSeedDatas = {
               new(Guid.NewGuid(), "Carlos", "Medina", "cgml02@hotmail.com", "superadmin2024", 1, new DateTime(2024, 01, 01)),
               new(Guid.NewGuid(), "Votante", "Prueba", "test@hotmail.com", "votante2024", 2, new DateTime(2024, 01, 01)),
          };

        builder.HasData(brandSeedDatas);

        #endregion SeedDatas
    }
}