using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesInWorkBySupplierId;

public class GetPurchaseResponsesInWorkBySupplierIdHandler : IRequestHandler<
    GetPurchaseResponsesInWorkBySupplierIdRequest, Result<GetPurchaseResponsesInWorkBySupplierIdResponse>>
{
    private readonly DataBaseContext _db;

    public GetPurchaseResponsesInWorkBySupplierIdHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetPurchaseResponsesInWorkBySupplierIdResponse>> Handle(
        GetPurchaseResponsesInWorkBySupplierIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseResponsesInWork = await _db.PurchaseResponses
            .Where(x => x.SupplierId == request.SupplierId && x.PurchaseRequest.SupplierId != null)
            .Select(x => new GetPurchaseResponsesInWorkBySupplierIdDto(
                x.Id,
                x.Cost,
                x.Comment,
                x.PurchaseRequestId,
                x.PurchaseRequest.ProductName,
                x.PurchaseRequest.Cost,
                x.PurchaseRequest.ProductCount,
                x.PurchaseRequest.BuyerId)).ToListAsync(cancellationToken: cancellationToken);
        return Result.Ok(new GetPurchaseResponsesInWorkBySupplierIdResponse(purchaseResponsesInWork));
    }
}