using MediatR;

namespace NPS.Application.Features.UserQuestionnaireOperations.Queries.GetUserQuestionnaireDetail;

public class GetUserQuestionnaireDetailQueryRequest : IRequest<GetUserQuestionnaireDetailQueryResponse>
{
    public int QuestionnaireId {  get; set; }
}