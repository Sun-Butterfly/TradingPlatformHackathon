using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesByBuyerId;

public class GetPurchaseResponsesByBuyerIdHandler
    : IRequestHandler<GetPurchaseResponsesByBuyerIdRequest,Result<GetPurchaseResponsesByBuyerIdResponse>>
{
    private readonly DataBaseContext _db;

    public GetPurchaseResponsesByBuyerIdHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetPurchaseResponsesByBuyerIdResponse>> Handle(GetPurchaseResponsesByBuyerIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseResponses = await _db.PurchaseResponses
            .Where(x => x.PurchaseRequest.BuyerId == request.BuyerId)
            .Select(x => new GetPurchaseResponsesByBuyerIdDto(
                x.Id,
                x.PurchaseRequestId,
                x.Cost,
                x.Comment)).ToListAsync(cancellationToken: cancellationToken);
        return Result.Ok(new GetPurchaseResponsesByBuyerIdResponse(purchaseResponses));
    }
}