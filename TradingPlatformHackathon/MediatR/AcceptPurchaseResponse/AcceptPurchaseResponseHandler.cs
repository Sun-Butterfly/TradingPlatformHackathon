using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Interfaces;

namespace TradingPlatformHackathon.MediatR.AcceptPurchaseResponse;

public class
    AcceptPurchaseResponseHandler : IRequestHandler<AcceptPurchaseResponseRequest,
        Result<AcceptPurchaseResponseResponse>>
{
    private readonly DataBaseContext _db;
    private readonly IService _service;

    public AcceptPurchaseResponseHandler(DataBaseContext db, IService service)
    {
        _db = db;
        _service = service;
    }

    public async Task<Result<AcceptPurchaseResponseResponse>> Handle(AcceptPurchaseResponseRequest request,
        CancellationToken cancellationToken)
    {
        var purchaseResponse = await _db.PurchaseResponses.FirstOrDefaultAsync(x => x.Id == request.PurchaseResponseId,
            cancellationToken: cancellationToken);
        if (purchaseResponse == null)
        {
            return Result.Fail("Отклик не найден");
        }
        await _service.SetSupplierIdToPurchaseRequest(purchaseResponse.PurchaseRequestId, purchaseResponse.SupplierId);
        return Result.Ok(new AcceptPurchaseResponseResponse());
    }
}