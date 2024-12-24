using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsNotInWorkByBuyerId;

public class GetPurchaseRequestsNotInWorkByBuyerIdHandler : IRequestHandler<GetPurchaseRequestNotInWorkByBuyerIdRequest, Result<GetPurchaseRequestNotInWorkByBuyerIdResponse>>
{
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;

    public GetPurchaseRequestsNotInWorkByBuyerIdHandler(IPurchaseRequestRepository purchaseRequestRepository)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
    }

    public async Task<Result<GetPurchaseRequestNotInWorkByBuyerIdResponse>> Handle(GetPurchaseRequestNotInWorkByBuyerIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequestsNotInWork =
            await _purchaseRequestRepository.GetNotInWorkByBuyerId(request.BuyerId, cancellationToken);
        return Result.Ok(new GetPurchaseRequestNotInWorkByBuyerIdResponse(purchaseRequestsNotInWork));
    }
}