using NPS.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace NPS.Domain.Entities;

public class UserEntity : BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}