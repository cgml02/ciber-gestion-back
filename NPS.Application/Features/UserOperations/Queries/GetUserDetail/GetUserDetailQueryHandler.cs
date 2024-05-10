using AutoMapper;
using MediatR;
using NPS.Application.Features.UserOperations.Rules;
using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;

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
        // Obtener usuario por Id
        UserEntity User = await _userRepository.GetByIdAsync(request.Id);

        // Verificar que el usuario exista
        _userBusinessRules.UserShouldExistWhenRequested(User);

        GetUserDetailQueryResponse mappedUser = _mapper.Map<GetUserDetailQueryResponse>(User);
        return mappedUser;
    }
}