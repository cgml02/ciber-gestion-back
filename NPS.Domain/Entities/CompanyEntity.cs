using NPS.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace NPS.Domain.Entities;

public class CompanyEntity : BaseEntity
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}