namespace NPS.Application.Features.UserOperations.Queries.GetUsers;

public class GetUsersQueryResponse
{
    public Guid Id { get; set; }
    public int ProfileId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}