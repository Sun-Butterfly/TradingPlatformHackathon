using FluentResults;
using MediatR;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.DeletePurchaseRequest;

public class
    DeletePurchaseRequestHandler : IRequestHandler<DeletePurchaseRequestRequest, Result<DeletePurchaseRequestResponse>>
{
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;
    private readonly IPurchaseResponseRepository _purchaseResponseRepository;

    public DeletePurchaseRequestHandler(IPurchaseRequestRepository purchaseRequestRepository, IPurchaseResponseRepository purchaseResponseRepository)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
        _purchaseResponseRepository = purchaseResponseRepository;
    }

    public async Task<Result<DeletePurchaseRequestResponse>> Handle(DeletePurchaseRequestRequest request,
        CancellationToken cancellationToken)
    {
        var isPurchaseRequestExists =
            await _purchaseRequestRepository.ExistsById(request.PurchaseRequestId, cancellationToken);
        if (!isPurchaseRequestExists)
        {
            return Result.Fail("Запрос на закупку не найден!");
        }

        await _purchaseRequestRepository.DeleteById(request.PurchaseRequestId, cancellationToken);
        await _purchaseResponseRepository.DeleteByPurchaseRequestId(request.PurchaseRequestId, cancellationToken);
        return Result.Ok(new DeletePurchaseRequestResponse());
    }
}