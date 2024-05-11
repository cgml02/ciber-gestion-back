using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPS.Domain.Entities;

namespace NPS.Infrastructure.Configurations;

public class RuleQuestionnaireConfiguration : IEntityTypeConfiguration<RuleQuestionnaireEntity>
{
    public void Configure(EntityTypeBuilder<RuleQuestionnaireEntity> builder)
    {
        #region Configurations

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.ScoreStart).IsRequired();
        builder.Property(x => x.ScoreEnd).IsRequired();
        builder.Property(x => x.Classification).HasMaxLength(100).IsRequired();

        #endregion Configurations

        #region SeedDatas

        RuleQuestionnaireEntity[] brandSeedDatas = {
               new(0, 6, "Detractores", 1, new DateTime(2024, 01, 01)) { Id = 1 },
               new(7, 8, "Neutros", 1, new DateTime(2024, 01, 01)) { Id = 2 },
               new(9, 10, "Promotores", 1, new DateTime(2024, 01, 01)) { Id = 3 },
          };

        builder.HasData(brandSeedDatas);

        #endregion SeedDatas
    }
}