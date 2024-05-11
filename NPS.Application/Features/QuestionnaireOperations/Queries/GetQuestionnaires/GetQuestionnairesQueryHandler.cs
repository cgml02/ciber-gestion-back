using AutoMapper;
using MediatR;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;

public class GetQuestionnairesQueryHandler : IRequestHandler<GetQuestionnairesQueryRequest, List<GetQuestionnairesQueryResponse>>
{
    private readonly IQuestionnaireRepository _questionnaireRepository;
    private readonly IUserQuestionnaireRepository _userQuestionnaireRepository;
    private readonly IMapper _mapper;

    public GetQuestionnairesQueryHandler(IQuestionnaireRepository questionnaireRepository, IUserQuestionnaireRepository userQuestionnaireRepository, IMapper mapper)
    {
        _questionnaireRepository = questionnaireRepository;
        _userQuestionnaireRepository = userQuestionnaireRepository;
        _mapper = mapper;
    }

    public async Task<List<GetQuestionnairesQueryResponse>> Handle(GetQuestionnairesQueryRequest request, CancellationToken cancellationToken)
    {
        var questionnaires = await _questionnaireRepository.GetAllAsync();

        if (questionnaires != null && request.UserId != null)
        {
            var userDoneQuestionnaires = await _userQuestionnaireRepository.GetAsync(x => x.UserId == request.UserId);
            if (userDoneQuestionnaires != null && userDoneQuestionnaires.Any())
            {
                var userDoneQuestionnaireIds = userDoneQuestionnaires.Select(x => x.QuestionnaireId).ToList();

                // Filtrar la lista de cuestionarios para quitar aquellos que el usuario ya ha completado
                questionnaires = questionnaires.Where(q => !userDoneQuestionnaireIds.Contains(q.Id)).ToList();
            }
        }

        List<GetQuestionnairesQueryResponse> mappedQuestionnaire = _mapper.Map<List<GetQuestionnairesQueryResponse>>(questionnaires);
        return mappedQuestionnaire;
    }
}