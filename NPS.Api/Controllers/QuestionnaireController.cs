using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;

namespace NPS.Api.Controllers;

public class QuestionnaireController : BaseController
{
    [HttpGet("{UserId}")]
    public async Task<IActionResult> GetQuestionnaires([FromRoute] GetQuestionnairesQueryRequest request)
          => Ok(await Mediator.Send(request));
}