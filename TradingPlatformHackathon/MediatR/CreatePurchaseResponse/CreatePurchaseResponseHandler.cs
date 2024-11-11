using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.MediatR.CreatePurchaseResponse;

public class CreatePurchaseResponseHandler : IRequestHandler<CreatePurchaseResponseRequest,
    Result<CreatePurchaseResponseResponse>>
{
    private readonly DataBaseContext _db;

    public CreatePurchaseResponseHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<CreatePurchaseResponseResponse>> Handle(CreatePurchaseResponseRequest request,
        CancellationToken cancellationToken)
    {
        var supplier =
            await _db.Users.FirstOrDefaultAsync(x => x.Id == request.SupplierId, cancellationToken: cancellationToken);
        if (supplier == null)
        {
            return Result.Fail("Пользователь не найден!");
        }

        var purchaseResponse = new PurchaseResponse()
        {
            PurchaseRequestId = request.PurchaseRequestId,
            Cost = request.Cost,
            Comment = request.Comment,
            SupplierId = supplier.Id
        };
        _db.Add(purchaseResponse);
        await _db.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(new CreatePurchaseResponseResponse());
    }
}