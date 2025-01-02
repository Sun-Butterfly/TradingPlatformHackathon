using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.CreateMessage;
using TradingPlatformHackathon.MediatR.GetChatInfoByUserId;
using TradingPlatformHackathon.MediatR.GetMessagesByUserAndCompanionIds;

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

    [HttpGet]
    [Authorize(Roles = "admin, buyer, supplier")]
    public async Task<IActionResult> GetMessagesByUserAndCompanionIds(long companionId)
    {
        var userId = HttpContext.GetUserId();
        var request = new GetMessagesByUserAndCompanionIdsRequest(userId, companionId);
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.MessagesByUserAndCompanionIds);
    }

    [HttpPost]
    [Authorize(Roles = "admin, buyer, supplier")]
    public async Task<IActionResult> CreateMessage([FromBody] CreateMessageDto createMessageDto)
    {
        var userId = HttpContext.GetUserId();
        var request = new CreateMessageRequest(
            userId,
            createMessageDto.CompanionId,
            createMessageDto.Text,
            DateTime.UtcNow,
            false);
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value);
    }
}