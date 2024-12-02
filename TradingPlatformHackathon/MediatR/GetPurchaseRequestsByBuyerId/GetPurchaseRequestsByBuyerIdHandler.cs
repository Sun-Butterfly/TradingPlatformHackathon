using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsByBuyerId;

public class GetPurchaseRequestsByBuyerIdHandler : IRequestHandler<GetPurchaseRequestByBuyerIdRequest, Result<GetPurchaseRequestByBuyerIdResponse>>
{
    private readonly DataBaseContext _db;

    public GetPurchaseRequestsByBuyerIdHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetPurchaseRequestByBuyerIdResponse>> Handle(GetPurchaseRequestByBuyerIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequests = await _db.PurchaseRequests
            .Where(x => x.BuyerId == request.BuyerId && x.SupplierId==null)
            .Select(x => new GetPurchaseRequestByBuyerIdDto(
                x.Id,
                x.ProductName,
                x.ProductCount,
                x.Cost)).ToListAsync(cancellationToken: cancellationToken);
        return Result.Ok(new GetPurchaseRequestByBuyerIdResponse(purchaseRequests));
    }
}