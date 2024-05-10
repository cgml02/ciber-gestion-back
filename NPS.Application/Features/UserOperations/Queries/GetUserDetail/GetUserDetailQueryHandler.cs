using AutoMapper;
using MediatR;
using NPS.Application.Features.UserOperations.Rules;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.UserOperations.Queries.GetUserDetail;

public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQueryRequest, GetUserDetailQueryResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public GetUserDetailQueryHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
    }

    public async Task<GetUserDetailQueryResponse> Handle(GetUserDetailQueryRequest request, CancellationToken cancellationToken)
    {
        // Verificar email y password
        var user = await _userRepository.GetAsync(b => b.Email == request.Email && b.Password == request.Password);

        // Verificar que esten correctos
        _userBusinessRules.UserShouldExistWhenRequested(user);

        GetUserDetailQueryResponse mappedUser = _mapper.Map<GetUserDetailQueryResponse>(user.First());
        return mappedUser;
    }
}