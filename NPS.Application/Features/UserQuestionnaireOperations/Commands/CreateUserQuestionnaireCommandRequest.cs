using MediatR;

namespace NPS.Application.Features.UserQuestionnaireOperations.Commands;

public class CreateUserQuestionnaireCommandRequest : IRequest<CreateUserQuestionnaireCommandResponse>
{
    public int Score { get; set; }
    public Guid UserId { get; set; }
    public int QuestionnaireId { get; set; }
}