using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.LogIn;

namespace TradingPlatformHackathon.Controllers;

[ApiController]
[Produces("application/json")]
[Route("[controller]/[action]")]
public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof (LogInResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof (ErrorModel), StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<IActionResult> LogIn([FromBody]LogInRequest logInRequest)
    {
        var result = await _mediator.Send(logInRequest);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        return Ok(result.Value);
    }
}