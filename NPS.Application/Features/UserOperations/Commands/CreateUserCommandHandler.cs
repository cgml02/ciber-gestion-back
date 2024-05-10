using AutoMapper;
using MediatR;
using NPS.Application.Features.UserOperations.Rules;
using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;

namespace NPS.Application.Features.UserOperations.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        // Verificar existencia email
        await _userBusinessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);

        // Map a entidad
        UserEntity mappedUser = _mapper.Map<UserEntity>(request);

        // Registrar usuario
        UserEntity createdUser = await _userRepository.AddAsync(mappedUser);
        await _userRepository.SaveAsync();

        return _mapper.Map<CreateUserCommandResponse>(createdUser);
    }
}