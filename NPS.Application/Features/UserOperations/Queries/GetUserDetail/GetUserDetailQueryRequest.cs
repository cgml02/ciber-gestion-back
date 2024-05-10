using MediatR;

namespace NPS.Application.Features.UserOperations.Queries.GetUserDetail;

public class GetUserDetailQueryRequest : IRequest<GetUserDetailQueryResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}