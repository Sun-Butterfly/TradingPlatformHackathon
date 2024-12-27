using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.GetChatInfoByUserId;

namespace TradingPlatformHackathon.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class MessageController : Controller
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "admin, buyer, supplier")]
    public async Task<IActionResult> GetChatInfoByUserId()
    {
        var userId = HttpContext.GetUserId();
        var request = new GetChatInfoByUserIdRequest(userId);
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.ChatInfos);
    }
}