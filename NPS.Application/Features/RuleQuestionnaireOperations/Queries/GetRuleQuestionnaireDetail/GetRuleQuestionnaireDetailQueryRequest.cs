using MediatR;

namespace NPS.Application.Features.RuleOperations.Queries.GetRuleQuestionnaireDetail;

public class GetRuleQuestionnaireDetailQueryRequest : IRequest<List<GetRuleQuestionnaireDetailQueryResponse>>
{
    public int QuestionnaireId { get; set; }
}