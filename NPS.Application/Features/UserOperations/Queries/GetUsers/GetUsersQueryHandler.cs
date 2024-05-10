using AutoMapper;
using MediatR;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.UserOperations.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, List<GetUsersQueryResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUsersQueryResponse>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
    {
        // Obtener usuario por Id
        var users = await _userRepository.GetAllAsync();

        List<GetUsersQueryResponse> mappedUser = _mapper.Map<List<GetUsersQueryResponse>>(users);
        return mappedUser;
    }
}