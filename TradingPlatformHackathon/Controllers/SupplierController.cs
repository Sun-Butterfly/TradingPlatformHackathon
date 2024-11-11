using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.CreatePurchaseResponse;

namespace TradingPlatformHackathon.Controllers;

[Produces("application/json")]
[Route("[controller]/[action]")]
public class SupplierController : Controller
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
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