namespace NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;

public class GetQuestionnairesQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public int CompanyId { get; set; }
}