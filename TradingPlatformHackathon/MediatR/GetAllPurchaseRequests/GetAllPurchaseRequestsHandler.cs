using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetAllPurchaseRequests;

public class GetAllPurchaseRequestsHandler : IRequestHandler<GetAllPurchaseRequestsRequest, Result<GetAllPurchaseRequestsResponse>>
{
    private readonly DataBaseContext _db;

    public GetAllPurchaseRequestsHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetAllPurchaseRequestsResponse>> Handle(GetAllPurchaseRequestsRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequests = await _db.PurchaseRequests.Where(x=>x.SupplierId==null)
            .Select(x =>
            new GetPurchaseRequestDto(
                x.Id,
                x.ProductName,
                x.ProductCount,
                x.Cost,
                x.BuyerId)).ToListAsync(cancellationToken: cancellationToken);
        return Result.Ok(new GetAllPurchaseRequestsResponse(purchaseRequests));
    }
}