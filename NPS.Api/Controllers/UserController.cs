using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.UserOperations.Commands;
using NPS.Application.Features.UserOperations.Queries.GetUserDetail;
using NPS.Application.Features.UserOperations.Queries.GetUsers;

namespace NPS.Api.Controllers;

public class UserController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
          => Ok(await Mediator.Send(new GetUsersQueryRequest()));

    [HttpPost("signup")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
    {
        CreateUserCommandResponse response = await Mediator.Send(request);
        return Created("", response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] GetUserDetailQueryRequest request)
    {
        GetUserDetailQueryResponse response = await Mediator.Send(request);
        return Created("", response);
    }
}