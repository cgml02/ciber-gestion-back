using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using NPS.Domain.Entities;
using NPS.Domain.Entities.Common;
using NPS.Infrastructure.Configurations;

namespace NPS.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
    {
    }

    #region Entities

    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<ProfileEntity> Profiles { get; set; }
    public DbSet<QuestionnaireEntity> Questionnaires { get; set; }
    public DbSet<RuleQuestionnaireEntity> RulesQuestionnaire { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserQuestionnaireEntity> UsersQuestionnaires { get; set; }

    #endregion Entities

    #region SaveChangesAsync

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    #endregion SaveChangesAsync

    #region Configurations

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionnaireConfiguration());
        modelBuilder.ApplyConfiguration(new RuleQuestionnaireConfiguration());
        modelBuilder.ApplyConfiguration(new UserQuestionnaireConfiguration());

        #region camelCase
        var camelCaseNamingStrategy = new CamelCaseNamingStrategy();
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                // Convertir el nombre de la columna a camelCase
                property.SetColumnName(ConvertToCamelCase(property.Name, camelCaseNamingStrategy));
            }
        }
        #endregion

        base.OnModelCreating(modelBuilder);
    }

    private string ConvertToCamelCase(string name, CamelCaseNamingStrategy strategy)
    {
        return strategy.GetPropertyName(name, false);
    }

    #endregion Configurations
}