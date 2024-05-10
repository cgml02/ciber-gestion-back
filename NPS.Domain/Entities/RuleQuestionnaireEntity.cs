using NPS.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace NPS.Domain.Entities;

public class RuleQuestionnaireEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public int ScoreStart { get; set; }
    public int ScoreEnd { get; set; }
    public string Classification { get; set; } = string.Empty;
}