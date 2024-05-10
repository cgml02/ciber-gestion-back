using MediatR;

namespace NPS.Application.Features.UserOperations.Queries.GetUserDetail;

public class GetUserDetailQueryRequest : IRequest<GetUserDetailQueryResponse>
{
    public string Id { get; set; } = string.Empty;
}