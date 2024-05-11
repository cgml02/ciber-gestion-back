using NPS.Domain.Entities.Common;

namespace NPS.Domain.Entities;

public class UserQuestionnaireEntity : BaseEntity
{
    public UserQuestionnaireEntity()
    {
    }

    public UserQuestionnaireEntity(int score, Guid userId, int questionnaireId, DateTime createdDate) : this()
    {
        Score = score;
        UserId = userId;
        QuestionnaireId = questionnaireId;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }

    public int Score { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public int QuestionnaireId { get; set; }
    public QuestionnaireEntity Questionnaire { get; set; }
}