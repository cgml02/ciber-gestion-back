using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NPS.Application.Features.UserOperations.Rules;
using System.Reflection;

namespace NPS.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // BusinessRules
        services.AddScoped<UserBusinessRules>();

        return services;
    }
}