using MediatR;

namespace NPS.Application.Features.UserOperations.Queries.GetUsers;

public class GetUsersQueryRequest : IRequest<List<GetUsersQueryResponse>>
{
}