using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetAllNotInWorkPurchaseRequests;

public class GetAllNotInWorkPurchaseRequestsHandler : IRequestHandler<GetAllNotInWorkPurchaseRequestsRequest, Result<GetAllNotInWorkPurchaseRequestsResponse>>
{
    private readonly PurchaseRequestRepository _purchaseRequestRepository
        ;

    public GetAllNotInWorkPurchaseRequestsHandler(PurchaseRequestRepository purchaseRequestRepository)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
    }

    public async Task<Result<GetAllNotInWorkPurchaseRequestsResponse>> Handle(GetAllNotInWorkPurchaseRequestsRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequestsNotInWork = await _purchaseRequestRepository.GetAllNotInWork(cancellationToken);
        return Result.Ok(new GetAllNotInWorkPurchaseRequestsResponse(purchaseRequestsNotInWork));
    }
}