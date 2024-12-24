using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsInWorkByBuyerId;

public class GetPurchaseRequestsInWorkByBuyerIdHandler : IRequestHandler<GetPurchaseRequestsInWorkByBuyerIdRequest,
    Result<GetPurchaseRequestsInWorkByBuyerIdResponse>>
{
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;

    public GetPurchaseRequestsInWorkByBuyerIdHandler(IPurchaseRequestRepository purchaseRequestRepository)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
    }

    public async Task<Result<GetPurchaseRequestsInWorkByBuyerIdResponse>> Handle(
        GetPurchaseRequestsInWorkByBuyerIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequestsInWork =
            await _purchaseRequestRepository.GetInWorkByBuyerId(request.BuyerId, cancellationToken);
        return Result.Ok(new GetPurchaseRequestsInWorkByBuyerIdResponse(purchaseRequestsInWork));
    }
}