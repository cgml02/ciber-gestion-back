using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.UserOperations.Queries.GetProfileDetail;

namespace NPS.Api.Controllers;

public class ProfileController : BaseController
{
    private readonly ILogger<ProfileController> _logger;

    public ProfileController(ILogger<ProfileController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProfileById([FromRoute] GetProfileDetailQueryRequest request)
    {
        _logger.LogInformation("Getting profile by ID: {Id}", request.Id);

        var profile = await Mediator.Send(request);

        _logger.LogInformation("Retrieved profile successfully");

        return Ok(profile);
    }
}