using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Services;

namespace TradingPlatformHackathon.MediatR.DeletePurchaseRequest;

public class
    DeletePurchaseRequestHandler : IRequestHandler<DeletePurchaseRequestRequest, Result<DeletePurchaseRequestResponse>>
{
    private readonly DataBaseContext _db;

    public DeletePurchaseRequestHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<DeletePurchaseRequestResponse>> Handle(DeletePurchaseRequestRequest request,
        CancellationToken cancellationToken)
    {
        var isPurchaseRequestExists = await _db.PurchaseRequests.AnyAsync(x => x.Id == request.PurchaseRequestId,
            cancellationToken);
        if (!isPurchaseRequestExists)
        {
            return Result.Fail("Запрос на закупку не найден!");
        }

        await _db.PurchaseRequests.Where(x => x.Id == request.PurchaseRequestId)
            .ExecuteDeleteAsync(cancellationToken);
        await _db.PurchaseResponses.Where(x => x.PurchaseRequestId == request.PurchaseRequestId)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
        return Result.Ok(new DeletePurchaseRequestResponse());
    }
}