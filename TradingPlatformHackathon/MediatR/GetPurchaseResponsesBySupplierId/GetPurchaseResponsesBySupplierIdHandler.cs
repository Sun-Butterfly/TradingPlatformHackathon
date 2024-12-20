using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesBySupplierId;

public class GetPurchaseResponsesBySupplierIdHandler : IRequestHandler<GetPurchaseResponsesBySupplierIdRequest, Result<GetPurchaseResponsesBySupplierIdResponse>>
{
    private readonly DataBaseContext _db;

    public GetPurchaseResponsesBySupplierIdHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<GetPurchaseResponsesBySupplierIdResponse>> Handle(GetPurchaseResponsesBySupplierIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseResponses = await _db.PurchaseResponses
            .Where(x => x.SupplierId == request.SupplierId)
            .Select(x => new GetPurchaseResponsesBySupplierIdDto(
                x.Id,
                x.PurchaseRequestId,
                x.Cost,
                x.Comment)).ToListAsync(cancellationToken: cancellationToken);
        return Result.Ok(new GetPurchaseResponsesBySupplierIdResponse(purchaseResponses));
    }
}