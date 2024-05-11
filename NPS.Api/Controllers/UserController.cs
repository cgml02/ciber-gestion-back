using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.UserOperations.Commands;
using NPS.Application.Features.UserOperations.Queries.GetUserDetail;
using NPS.Application.Features.UserOperations.Queries.GetUsers;

namespace NPS.Api.Controllers;

public class UserController : BaseController
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        _logger.LogInformation("Getting users");

        var users = await Mediator.Send(new GetUsersQueryRequest());

        _logger.LogInformation("Retrieved users successfully");

        return Ok(users);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
    {
        _logger.LogInformation("Creating user");

        var response = await Mediator.Send(request);

        _logger.LogInformation("User created successfully");

        return Created("", response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] GetUserDetailQueryRequest request)
    {
        _logger.LogInformation("Logging in user");

        var response = await Mediator.Send(request);

        _logger.LogInformation("User logged in successfully");

        return Created("", response);
    }
}