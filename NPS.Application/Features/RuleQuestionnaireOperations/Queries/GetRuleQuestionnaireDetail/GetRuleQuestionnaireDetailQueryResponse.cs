namespace NPS.Application.Features.RuleOperations.Queries.GetRuleQuestionnaireDetail;

public class GetRuleQuestionnaireDetailQueryResponse
{
    public int Id { get; set; }
    public int ScoreStart { get; set; }
    public int ScoreEnd { get; set; }
    public string Classification { get; set; } = string.Empty;
    public int QuestionnaireId { get; set; }
}