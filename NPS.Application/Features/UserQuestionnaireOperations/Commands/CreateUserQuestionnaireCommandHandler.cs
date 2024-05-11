using AutoMapper;
using MediatR;
using NPS.Application.Features.UserQuestionnaireOperations.Rules;
using NPS.Application.Interfaces.Repositories;
using NPS.Domain.Entities;

namespace NPS.Application.Features.UserQuestionnaireOperations.Commands;

public class CreateUserQuestionnaireCommandHandler : IRequestHandler<CreateUserQuestionnaireCommandRequest, CreateUserQuestionnaireCommandResponse>
{
    private readonly IUserQuestionnaireRepository _userQuestionnaireRepository;
    private readonly UserQuestionnaireBusinessRules _userQuestionnaireBusiness;
    private readonly IMapper _mapper;

    public CreateUserQuestionnaireCommandHandler(IUserQuestionnaireRepository userQuestionnaireRepository, UserQuestionnaireBusinessRules userQuestionnaireBusiness, IMapper mapper)
    {
        _userQuestionnaireRepository = userQuestionnaireRepository;
        _userQuestionnaireBusiness = userQuestionnaireBusiness;
        _mapper = mapper;
    }

    public async Task<CreateUserQuestionnaireCommandResponse> Handle(CreateUserQuestionnaireCommandRequest request, CancellationToken cancellationToken)
    {
        // Verificar que el usuario no haya respondido ya al cuestionario
        await _userQuestionnaireBusiness.QuestionnaireCanNotBeDuplicatedWhenInserted(request);

        // Map a entidad
        UserQuestionnaireEntity mappedUserQuestionnaire = _mapper.Map<UserQuestionnaireEntity>(request);

        // Registrar encuesta respondida por el usuario
        UserQuestionnaireEntity createdUserQuestionnaire = await _userQuestionnaireRepository.AddAsync(mappedUserQuestionnaire);
        await _userQuestionnaireRepository.SaveAsync();

        return _mapper.Map<CreateUserQuestionnaireCommandResponse>(createdUserQuestionnaire);
    }
}