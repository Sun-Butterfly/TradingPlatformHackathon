using FluentResults;
using MediatR;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.RedactPurchaseRequest;

public class RedactPurchaseRequestHandler : IRequestHandler<RedactPurchaseRequestRequest, Result<RedactPurchaseRequestResponse>>
{
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;

    public RedactPurchaseRequestHandler(IPurchaseRequestRepository purchaseRequestRepository)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
    }

    public async Task<Result<RedactPurchaseRequestResponse>> Handle(RedactPurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequest = await _purchaseRequestRepository.GetById(request.PurchaseRequestId, cancellationToken);
        purchaseRequest.ProductName = request.ProductName;
        purchaseRequest.ProductCount = request.ProductCount;
        purchaseRequest.Cost = request.Cost;
        
        _purchaseRequestRepository.Update(purchaseRequest);
        await _purchaseRequestRepository.SaveChanges(cancellationToken);

        return Result.Ok(new RedactPurchaseRequestResponse());
    }
}