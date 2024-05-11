using MediatR;

namespace NPS.Application.Features.UserOperations.Queries.GetProfileDetail;

public class GetProfileDetailQueryRequest : IRequest<GetProfileDetailQueryResponse>
{
    public int Id { get; set; }
}