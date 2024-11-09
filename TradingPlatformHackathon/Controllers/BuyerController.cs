using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.CreatePurchaseRequest;

namespace TradingPlatformHackathon.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class BuyerController : Controller
{
    private readonly IMediator _mediator;

    public BuyerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "admin, buyer")]
    public async Task<IActionResult> CreatePurchaseRequest([FromBody] PurchaseRequestDto purchaseRequestDto)
    {
        var userId = HttpContext.GetUserId();
        var request = new CreatePurchaseRequestRequest(
            purchaseRequestDto.ProductName,
            purchaseRequestDto.ProductCount,
            purchaseRequestDto.Cost,
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