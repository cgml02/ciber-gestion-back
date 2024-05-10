using FluentValidation;

namespace NPS.Application.Features.UserOperations.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandValidator()
    {
        RuleFor(n => n.FirstName).NotEmpty();
        RuleFor(n => n.FirstName).NotNull();
        RuleFor(n => n.FirstName).MinimumLength(2);

        RuleFor(n => n.LastName).NotEmpty();
        RuleFor(n => n.LastName).NotNull();
        RuleFor(n => n.LastName).MinimumLength(2);

        RuleFor(n => n.Email).NotEmpty();
        RuleFor(n => n.Email).NotNull();

        RuleFor(n => n.Password).NotEmpty();
        RuleFor(n => n.Password).NotNull();
    }
}