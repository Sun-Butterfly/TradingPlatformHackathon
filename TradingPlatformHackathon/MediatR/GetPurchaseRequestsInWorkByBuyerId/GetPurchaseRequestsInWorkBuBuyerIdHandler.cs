using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsInWorkByBuyerId;

public class GetPurchaseRequestsInWorkBuBuyerIdHandler : IRequestHandler<GetPurchaseRequestsInWorkBuBuyerIdRequest,
    Result<GetPurchaseRequestsInWorkBuBuyerIdResponse>>
{
    private readonly DataBaseContext _db;

    public GetPurchaseRequestsInWorkBuBuyerIdHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetPurchaseRequestsInWorkBuBuyerIdResponse>> Handle(
        GetPurchaseRequestsInWorkBuBuyerIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequestsInWork = await _db.PurchaseRequests
            .Where(x => x.BuyerId == request.BuyerId && x.SupplierId!=null)
            .Include(x => x.PurchaseResponses)
            .SelectMany(x => x.PurchaseResponses!.Select(y => new GetPurchaseRequestsInWorkByBuyerIdDto(
                x.Id,
                x.ProductName,
                x.Cost,
                x.ProductCount,
                y.SupplierId,
                y.Id,
                y.Cost,
                y.Comment))).ToListAsync(cancellationToken);
        return Result.Ok(new GetPurchaseRequestsInWorkBuBuyerIdResponse(purchaseRequestsInWork));
    }
}