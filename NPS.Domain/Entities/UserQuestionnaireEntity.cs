using NPS.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace NPS.Domain.Entities;

public class UserQuestionnaireEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public int Score { get; set; }
}