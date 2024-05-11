using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.UserQuestionnaireOperations.Commands;
using NPS.Application.Features.UserQuestionnaireOperations.Queries.GetUserQuestionnaireDetail;

namespace NPS.Api.Controllers;

public class UserQuestionnaireController : BaseController
{
    private readonly ILogger<UserQuestionnaireController> _logger;

    public UserQuestionnaireController(ILogger<UserQuestionnaireController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{QuestionnaireId}")]
    public async Task<IActionResult> GetUserQuestionnaires([FromRoute] GetUserQuestionnaireDetailQueryRequest request)
    {
        _logger.LogInformation("Getting user questionnaires for questionnaire ID: {QuestionnaireId}", request.QuestionnaireId);

        var userQuestionnaires = await Mediator.Send(request);

        _logger.LogInformation("Retrieved user questionnaires successfully");

        return Ok(userQuestionnaires);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserQuestionnaire([FromBody] CreateUserQuestionnaireCommandRequest request)
    {
        _logger.LogInformation("Creating user questionnaire");

        var response = await Mediator.Send(request);

        _logger.LogInformation("User questionnaire created successfully");

        return Created("", response);
    }
}