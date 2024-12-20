using EmployeesCRUD;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.MediatR.CreatePurchaseResponse;
using TradingPlatformHackathon.MediatR.DeletePurchaseResponse;
using TradingPlatformHackathon.MediatR.GetPurchaseResponsesByBuyerId;
using TradingPlatformHackathon.MediatR.GetPurchaseResponsesBySupplierId;
using TradingPlatformHackathon.MediatR.GetPurchaseResponsesInWorkBySupplierId;

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
    
    [HttpDelete]
    [Authorize(Roles = "admin, supplier")]
    public async Task<IActionResult> DeletePurchaseResponse(long purchaseResponseId)
    {
        var request = new DeletePurchaseResponseRequest(purchaseResponseId);
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Authorize(Roles = "admin, supplier")]
    public async Task<IActionResult> GetPurchaseResponsesBySupplierId(long supplierId)
    {
        var request = new GetPurchaseResponsesBySupplierIdRequest(supplierId);
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.PurchaseResponses);
    }

    [HttpGet]
    [Authorize(Roles = "admin, supplier")]
    public async Task<IActionResult> GetPurchaseResponsesInWorkBySupplierId(long supplierId)
    {
        var request = new GetPurchaseResponsesInWorkBySupplierIdRequest(supplierId);
        var result = await _mediator.Send(request);
        
        if (result.IsFailed)
        {
            return BadRequest(new ErrorModel(result.StringifyErrors()));
        }

        return Ok(result.Value.PurchaseResponsesInWork);
    }
}