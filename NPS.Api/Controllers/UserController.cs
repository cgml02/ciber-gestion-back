using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.UserOperations.Commands;
using NPS.Application.Features.UserOperations.Queries.GetUserDetail;
using NPS.Application.Features.UserOperations.Queries.GetUsers;

namespace NPS.Api.Controllers;

public class UserController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersQueryRequest request)
          => Ok(await Mediator.Send(request));

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserById([FromRoute] GetUserDetailQueryRequest request)
          => Ok(await Mediator.Send(request));

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
    {
        CreateUserCommandResponse response = await Mediator.Send(request);
        return Created("", response);
    }
}