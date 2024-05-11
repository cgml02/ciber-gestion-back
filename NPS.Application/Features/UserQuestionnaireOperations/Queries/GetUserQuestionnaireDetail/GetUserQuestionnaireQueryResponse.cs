namespace NPS.Application.Features.UserQuestionnaireOperations.Queries.GetUserQuestionnaireDetail;

public class GetUserQuestionnaireDetailQueryResponse
{
    public List<ClassificationDetailQueryResponse>? ClassificationDetail { get; set; }
    public double TotalNps { get; set; } = 0;
}

public class ClassificationDetailQueryResponse
{
    public string Classification { get; set; } = string.Empty;
    public int Score { get; set; } = 0;
}