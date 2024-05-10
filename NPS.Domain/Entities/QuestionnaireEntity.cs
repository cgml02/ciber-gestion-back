using NPS.Domain.Entities.Common;

namespace NPS.Domain.Entities;

public class QuestionnaireEntity : BaseEntity
{
    public QuestionnaireEntity()
    {
    }

    public QuestionnaireEntity(string name, string question, DateTime createdDate) : this()
    {
        Name = name;
        Question = question;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;

    public int CompanyId { get; set; }
    public CompanyEntity Company { get; set; }

    public ICollection<UserQuestionnaireEntity> UserQuestionnaires { get; set; }
    public ICollection<RuleQuestionnaireEntity> RuleQuestionnaires { get; set; }
}