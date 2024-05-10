using NPS.Domain.Entities.Common;

namespace NPS.Domain.Entities;

public class RuleQuestionnaireEntity : BaseEntity
{
    public RuleQuestionnaireEntity()
    {
    }

    public RuleQuestionnaireEntity(int scoreStart, int scoreEnd, string classification, int questionnaireId, DateTime createdDate) : this()
    {
        ScoreStart = scoreStart;
        ScoreEnd = scoreEnd;
        Classification = classification;
        QuestionnaireId = questionnaireId;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }

    public int ScoreStart { get; set; }
    public int ScoreEnd { get; set; }
    public string Classification { get; set; } = string.Empty;

    public int QuestionnaireId { get; set; }
    public QuestionnaireEntity Questionnaire { get; set; }
}