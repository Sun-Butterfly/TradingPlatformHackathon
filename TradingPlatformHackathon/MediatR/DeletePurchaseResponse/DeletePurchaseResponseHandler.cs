using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TradingPlatformHackathon.MediatR.DeletePurchaseResponse;

public class
    DeletePurchaseResponseHandler : IRequestHandler<DeletePurchaseResponseRequest,
        Result<DeletePurchaseResponseResponse>>
{
    private readonly DataBaseContext _db;

    public DeletePurchaseResponseHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<DeletePurchaseResponseResponse>> Handle(DeletePurchaseResponseRequest request,
        CancellationToken cancellationToken)
    {
        var isPurchaseResponseExists = await _db.PurchaseResponses.AnyAsync(x => x.Id == request.PurchaseResponseId,
            cancellationToken: cancellationToken);
        if (!isPurchaseResponseExists)
        {
            return Result.Fail("Отклик не найден");
        }

        await _db.PurchaseResponses.Where(x => x.Id == request.PurchaseResponseId)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
        return Result.Ok(new DeletePurchaseResponseResponse());
    }
}