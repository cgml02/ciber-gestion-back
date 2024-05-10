using MediatR;

namespace NPS.Application.Features.UserOperations.Queries.GetUserDetail;

public class GetUserDetailQueryRequest : IRequest<GetUserDetailQueryResponse>
{
    public Guid Id { get; set; }
}