using NPS.Domain.Entities.Common;

namespace NPS.Domain.Entities;

public class UserEntity : BaseEntity
{
    public UserEntity()
    {
    }

    public UserEntity(Guid id, string firstName, string lastName, string email, string password, int profileId, DateTime createdDate) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        ProfileId = profileId;
        CreatedDate = createdDate;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public int ProfileId { get; set; }
    public ProfileEntity Profile { get; set; }

    public ICollection<UserQuestionnaireEntity> UserQuestionnaires { get; set; }
}