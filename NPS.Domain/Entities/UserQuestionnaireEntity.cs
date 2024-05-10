using NPS.Domain.Entities.Common;

namespace NPS.Domain.Entities;

public class UserQuestionnaireEntity : BaseEntity
{
    public UserQuestionnaireEntity()
    {
    }

    public UserQuestionnaireEntity(int score, DateTime createdDate) : this()
    {
        Score = score;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }

    public int Score { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; }

    public int QuestionnaireId { get; set; }
    public QuestionnaireEntity Questionnaire { get; set; }
}