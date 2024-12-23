using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.DeletePurchaseResponse;

public class
    DeletePurchaseResponseHandler : IRequestHandler<DeletePurchaseResponseRequest,
        Result<DeletePurchaseResponseResponse>>
{
    private readonly PurchaseResponseRepository _purchaseResponseRepository;

    public DeletePurchaseResponseHandler(PurchaseResponseRepository purchaseResponseRepository)
    {
        _purchaseResponseRepository = purchaseResponseRepository;
    }

    public async Task<Result<DeletePurchaseResponseResponse>> Handle(DeletePurchaseResponseRequest request,
        CancellationToken cancellationToken)
    {
        var isPurchaseResponseExists =
            await _purchaseResponseRepository.ExistsById(request.PurchaseResponseId, cancellationToken);
        if (!isPurchaseResponseExists)
        {
            return Result.Fail("Отклик не найден");
        }

        await _purchaseResponseRepository.DeleteById(request.PurchaseResponseId, cancellationToken);
        return Result.Ok(new DeletePurchaseResponseResponse());
    }
}