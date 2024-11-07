using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.MediatR.CreatePurchaseRequest;

public class CreatePurchaseRequestHandler : IRequestHandler<CreatePurchaseRequestRequest, Result<CreatePurchaseRequestResponse>>
{
    private readonly DataBaseContext _db;

    public CreatePurchaseRequestHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<CreatePurchaseRequestResponse>> Handle(CreatePurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        var buyer = await _db.Users.FirstOrDefaultAsync(x => x.Id == request.BuyerId, cancellationToken: cancellationToken);
        if (buyer == null)
        {
            return Result.Fail("Пользователь не найден!");
        }

        var purchaseRequest = new PurchaseRequest()
        {
            ProductName = request.ProductName,
            ProductCount = request.ProductCount,
            Cost = request.Cost,
            BuyerId = buyer.Id
        };
        _db.Add(purchaseRequest);
        await _db.SaveChangesAsync(cancellationToken);
        return Result.Ok(new CreatePurchaseRequestResponse());
    }
}