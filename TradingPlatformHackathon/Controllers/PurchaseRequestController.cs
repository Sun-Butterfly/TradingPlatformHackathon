using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.GetAllPurchaseRequests;
using TradingPlatformHackathon.MediatR.GetPurchaseRequestsByBuyerId;

namespace TradingPlatformHackathon.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class PurchaseRequestController : Controller
{
    private readonly IMediator _mediator;

    public PurchaseRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllPurchaseRequests()
    {
        var request = new GetAllPurchaseRequestsRequest();
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.PurchaseRequests);
    }

    [HttpGet]
    [Authorize(Roles = "admin, buyer")]
    public async Task<IActionResult> GetPurchaseRequestByBuyerId(long buyerId)
    {
        var request = new GetPurchaseRequestByBuyerIdRequest(buyerId);
        var result = await _mediator.Send(request);
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }
        
        return Ok(result.Value.PurchaseRequests);
    }
}