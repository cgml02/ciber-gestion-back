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

        #endregion Microsoft SQL Server

        #region Repositories

        services.AddScoped<IUserRepository, UserRepository>();

        #endregion Repositories

        return services;
    }
}