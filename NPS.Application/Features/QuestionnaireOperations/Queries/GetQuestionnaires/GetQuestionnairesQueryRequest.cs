using MediatR;

namespace NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;

public class GetQuestionnairesQueryRequest : IRequest<List<GetQuestionnairesQueryResponse>>
{
    public Guid? UserId { get; set; }
}