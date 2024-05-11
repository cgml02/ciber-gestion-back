namespace NPS.Application.Features.UserQuestionnaireOperations.Commands;

public class CreateUserQuestionnaireCommandResponse
{
    public int Id { get; set; }
    public int Score { get; set; }
    public Guid UserId { get; set; }
    public int QuestionnaireId { get; set; }
}