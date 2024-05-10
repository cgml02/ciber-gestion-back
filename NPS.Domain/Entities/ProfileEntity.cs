using NPS.Domain.Entities.Common;

namespace NPS.Domain.Entities;

public class ProfileEntity : BaseEntity
{
    public ProfileEntity()
    {
    }

    public ProfileEntity(string name, string description, DateTime createdDate) : this()
    {
        Name = name;
        Description = description;
        CreatedDate = createdDate;
    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<UserEntity> Users { get; set; }
}