using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPS.Domain.Entities;

namespace NPS.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        #region Configurations

        builder.Property(x => x.FirstName).HasMaxLength(150).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(150).IsRequired();

        #endregion Configurations

        #region ForeingKey

        builder.HasMany(x => x.UserQuestionnaires)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        #endregion ForeingKey

        #region SeedDatas

        UserEntity[] brandSeedDatas = {
               new(Guid.NewGuid(), "Carlos", "Medina", "cgml02@hotmail.com", "uH/y/Lr+GZjtUuJuhg1os6THungwxmTxYnLasuzhxq9obhaC", 1, new DateTime(2024, 01, 01)),
               new(Guid.NewGuid(), "Votante", "Prueba", "test@hotmail.com", "3AseC+IKT6jv9tj2OauK6I+M3OvzJOK2JGGk5ajBvBlrNkXk", 2, new DateTime(2024, 01, 01)),
          };

        builder.HasData(brandSeedDatas);

        #endregion SeedDatas
    }
}