using NPS.Domain.Entities.Common;

namespace NPS.Domain.Entities;

public class CompanyEntity : BaseEntity
{
    public CompanyEntity()
    {
    }

    public CompanyEntity(string name, DateTime createdDate) : this()
    {
        Name = name;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<QuestionnaireEntity> Questionnaires { get; set; }
}