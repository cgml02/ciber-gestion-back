using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.QuestionnaireOperations.Queries.GetQuestionnaires;

namespace NPS.Api.Controllers;

public class QuestionnaireController : BaseController
{
    private readonly ILogger<QuestionnaireController> _logger;

    public QuestionnaireController(ILogger<QuestionnaireController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{UserId}")]
    public async Task<IActionResult> GetQuestionnaires([FromRoute] GetQuestionnairesQueryRequest request)
    {
        _logger.LogInformation("Getting questionnaires for user with ID: {UserId}", request.UserId);

        var questionnaires = await Mediator.Send(request);

        _logger.LogInformation("Retrieved questionnaires successfully");

        return Ok(questionnaires);
    }
}