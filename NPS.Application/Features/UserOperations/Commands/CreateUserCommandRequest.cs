using MediatR;

namespace NPS.Application.Features.UserOperations.Commands;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}