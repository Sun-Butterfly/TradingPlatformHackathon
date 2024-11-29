using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.CreatePurchaseResponse;
using TradingPlatformHackathon.MediatR.GetPurchaseResponsesByBuyerId;

namespace TradingPlatformHackathon.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class PurchaseResponseController : Controller
{
    private readonly IMediator _mediator;

    public PurchaseResponseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "admin, buyer")]
    public async Task<IActionResult> GetPurchaseResponsesByBuyerId(long buyerId)
    {
        var request = new GetPurchaseResponsesByBuyerIdRequest(buyerId);
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        
        return Ok(result.Value.PurchaseResponses);
        
    }
    
    [HttpPost]
    [Authorize(Roles = "admin, supplier")]
    public async Task<IActionResult> CreatePurchaseResponse([FromBody] PurchaseResponseDto purchaseResponseDto)
    {
        var userId = HttpContext.GetUserId();
        var request = new CreatePurchaseResponseRequest(
            purchaseResponseDto.PurchaseRequestId,
            purchaseResponseDto.Cost,
            purchaseResponseDto.Comment,
            userId
        );
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value);
    }
}