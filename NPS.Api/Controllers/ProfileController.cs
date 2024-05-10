using Microsoft.AspNetCore.Mvc;
using NPS.Api.Controllers.Base;
using NPS.Application.Features.UserOperations.Queries.GetProfileDetail;

namespace NPS.Api.Controllers;

public class ProfileController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProfileById([FromRoute] GetProfileDetailQueryRequest request)
          => Ok(await Mediator.Send(request));
}