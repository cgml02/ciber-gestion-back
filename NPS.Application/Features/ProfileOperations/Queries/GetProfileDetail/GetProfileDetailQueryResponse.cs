namespace NPS.Application.Features.UserOperations.Queries.GetProfileDetail;

public class GetProfileDetailQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}