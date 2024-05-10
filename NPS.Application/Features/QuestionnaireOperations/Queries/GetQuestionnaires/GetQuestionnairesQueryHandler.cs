using AutoMapper;
using MediatR;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;

public class GetQuestionnairesQueryHandler : IRequestHandler<GetQuestionnairesQueryRequest, List<GetQuestionnairesQueryResponse>>
{
    private readonly IQuestionnaireRepository _QuestionnaireRepository;
    private readonly IMapper _mapper;

    public GetQuestionnairesQueryHandler(IQuestionnaireRepository QuestionnaireRepository, IMapper mapper)
    {
        _QuestionnaireRepository = QuestionnaireRepository;
        _mapper = mapper;
    }

    public async Task<List<GetQuestionnairesQueryResponse>> Handle(GetQuestionnairesQueryRequest request, CancellationToken cancellationToken)
    {
        var questionnaires = await _QuestionnaireRepository.GetAllAsync();

        List<GetQuestionnairesQueryResponse> mappedQuestionnaire = _mapper.Map<List<GetQuestionnairesQueryResponse>>(questionnaires);
        return mappedQuestionnaire;
    }
}