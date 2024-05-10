using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;

namespace NPS.Api.Controllers;

public class QuestionnaireController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetQuestionnaires()
          => Ok(await Mediator.Send(new GetQuestionnairesQueryRequest()));
}