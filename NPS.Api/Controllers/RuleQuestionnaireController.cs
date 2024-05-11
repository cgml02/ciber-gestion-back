using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.RuleOperations.Queries.GetRuleQuestionnaireDetail;

namespace NPS.Api.Controllers;

public class RuleQuestionnaireController : BaseController
{
    private readonly ILogger<RuleQuestionnaireController> _logger;

    public RuleQuestionnaireController(ILogger<RuleQuestionnaireController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{QuestionnaireId}")]
    public async Task<IActionResult> GetRuleQuestionnaireByQuestionnaireId([FromRoute] GetRuleQuestionnaireDetailQueryRequest request)
    {
        _logger.LogInformation("Getting rule questionnaire by questionnaire ID: {QuestionnaireId}", request.QuestionnaireId);

        var ruleQuestionnaire = await Mediator.Send(request);

        _logger.LogInformation("Retrieved rule questionnaire successfully");

        return Ok(ruleQuestionnaire);
    }
}