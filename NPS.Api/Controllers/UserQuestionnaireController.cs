using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.UserQuestionnaireOperations.Commands;
using NPS.Application.Features.UserQuestionnaireOperations.Queries.GetUserQuestionnaireDetail;

namespace NPS.Api.Controllers;

public class UserQuestionnaireController : BaseController
{
    [HttpGet("{QuestionnaireId}")]
    public async Task<IActionResult> GetUserQuestionnaires([FromRoute] GetUserQuestionnaireDetailQueryRequest request)
          => Ok(await Mediator.Send(request));

    [HttpPost]
    public async Task<IActionResult> CreateUserQuestionnaire([FromBody] CreateUserQuestionnaireCommandRequest request)
    {
        CreateUserQuestionnaireCommandResponse response = await Mediator.Send(request);
        return Created("", response);
    }
}