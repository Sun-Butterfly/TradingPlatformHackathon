using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.Register;

namespace TradingPlatformHackathon.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class RegisterController : Controller
{
    private readonly IMediator _mediator;

    public RegisterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody]RegisterUserRequestDto registerUserRequestDto)
    {
        var request = new RegisterRequest(
            registerUserRequestDto.Email,
            registerUserRequestDto.Password,
            registerUserRequestDto.Name,
            registerUserRequestDto.Address,
            registerUserRequestDto.PhoneNumber,
            registerUserRequestDto.RoleId
        );
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value);
    }
}