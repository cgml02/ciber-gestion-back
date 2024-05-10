using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPS.Domain.Entities;

namespace NPS.Infrastructure.Configurations;

public class UserQuestionnaireConfiguration : IEntityTypeConfiguration<UserQuestionnaireEntity>
{
    public void Configure(EntityTypeBuilder<UserQuestionnaireEntity> builder)
    {
        #region Configurations

        builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
        builder.Property(x => x.Score).IsRequired();

        #endregion Configurations
    }
}