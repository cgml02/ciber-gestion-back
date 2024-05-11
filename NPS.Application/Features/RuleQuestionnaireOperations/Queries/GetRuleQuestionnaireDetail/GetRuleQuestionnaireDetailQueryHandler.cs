using AutoMapper;
using MediatR;
using NPS.Application.Features.RuleOperations.Queries.GetRuleQuestionnaireDetail;
using NPS.Application.Interfaces.Repositories;

namespace NPS.Application.Features.RuleQuestionnaireOperations.Queries.GetRuleQuestionnaireDetail;

public class GetRuleQuestionnaireDetailQueryHandler : IRequestHandler<GetRuleQuestionnaireDetailQueryRequest, List<GetRuleQuestionnaireDetailQueryResponse>>
{
    private readonly IRuleQuestionnaireRepository _ruleQuestionnaireRepository;
    private readonly IMapper _mapper;

    public GetRuleQuestionnaireDetailQueryHandler(IRuleQuestionnaireRepository ruleQuestionnaireRepository, IMapper mapper)
    {
        _ruleQuestionnaireRepository = ruleQuestionnaireRepository;
        _mapper = mapper;
    }

    public async Task<List<GetRuleQuestionnaireDetailQueryResponse>> Handle(GetRuleQuestionnaireDetailQueryRequest request, CancellationToken cancellationToken)
    {
        var ruleQuestionnaire = await _ruleQuestionnaireRepository.GetAsync(b => b.QuestionnaireId == request.QuestionnaireId);

        List<GetRuleQuestionnaireDetailQueryResponse> mappedRuleQuestionnaire = _mapper.Map<List<GetRuleQuestionnaireDetailQueryResponse>>(ruleQuestionnaire);
        return mappedRuleQuestionnaire;
    }
}