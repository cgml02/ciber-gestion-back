using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.RuleOperations.Queries.GetRuleQuestionnaireDetail;

namespace NPS.Api.Controllers;

public class RuleQuestionnaireController : BaseController
{
    [HttpGet("{QuestionnaireId}")]
    public async Task<IActionResult> GetRuleQuestionnaireByQuestionnaireId([FromRoute] GetRuleQuestionnaireDetailQueryRequest request)
          => Ok(await Mediator.Send(request));
}