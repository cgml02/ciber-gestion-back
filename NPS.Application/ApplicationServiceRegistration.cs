using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NPS.Application.Features.UserOperations.Rules;
using NPS.Application.Features.UserQuestionnaireOperations.Rules;
using NPS.Application.Validations;
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
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        // BusinessRules
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<UserQuestionnaireBusinessRules>();

        return services;
    }
}