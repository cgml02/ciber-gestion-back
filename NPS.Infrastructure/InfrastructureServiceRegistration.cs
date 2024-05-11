using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NPS.Application.Interfaces.Repositories;
using NPS.Infrastructure.Data;
using NPS.Infrastructure.Repositories;

namespace NPS.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
          IConfiguration configuration)
    {
        #region Microsoft SQL Server

        services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }

        #endregion Microsoft SQL Server

        #region Repositories

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
        services.AddScoped<IRuleQuestionnaireRepository, RuleQuestionnaireRepository>();
        services.AddScoped<IUserQuestionnaireRepository, UserQuestionnaireRepository>();

        #endregion Repositories

        return services;
    }
}