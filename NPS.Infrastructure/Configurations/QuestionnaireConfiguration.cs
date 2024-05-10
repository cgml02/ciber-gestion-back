using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPS.Domain.Entities;

namespace NPS.Infrastructure.Configurations;

public class QuestionnaireConfiguration : IEntityTypeConfiguration<QuestionnaireEntity>
{
    public void Configure(EntityTypeBuilder<QuestionnaireEntity> builder)
    {
        #region Configurations

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Question).IsRequired();

        #endregion Configurations

        #region ForeingKey

        builder.HasMany(x => x.UserQuestionnaires)
                    .WithOne(x => x.Questionnaire)
                    .HasForeignKey(x => x.QuestionnaireId)
                    .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.RuleQuestionnaires)
                    .WithOne(x => x.Questionnaire)
                    .HasForeignKey(x => x.QuestionnaireId)
                    .OnDelete(DeleteBehavior.Restrict);

        #endregion ForeingKey

        #region SeedDatas

        QuestionnaireEntity[] brandSeedDatas = {
               new("NPS",
               "¿Cuán probable es que recomiende el producto o servicio a un familiar o amigo? " +
               "Para ello se les pide calificar en una escala de 0 a 10, donde 0 es «Muy improbable» " +
               "y 10 es «Definitivamente lo recomendaría»", 1, new DateTime(2024, 01, 01)) { Id = 1 },
          };

        builder.HasData(brandSeedDatas);

        #endregion SeedDatas
    }
}