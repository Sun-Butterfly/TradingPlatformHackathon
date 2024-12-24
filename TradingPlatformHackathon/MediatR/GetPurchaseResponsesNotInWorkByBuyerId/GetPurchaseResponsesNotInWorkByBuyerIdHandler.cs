using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesNotInWorkByBuyerId;

public class GetPurchaseResponsesNotInWorkByBuyerIdHandler
    : IRequestHandler<GetPurchaseResponsesNotInWorkByBuyerIdRequest,Result<GetPurchaseResponsesNotInWorkByBuyerIdResponse>>
{
    private readonly IPurchaseResponseRepository _purchaseResponseRepository;

    public GetPurchaseResponsesNotInWorkByBuyerIdHandler(IPurchaseResponseRepository purchaseResponseRepository)
    {
        _purchaseResponseRepository = purchaseResponseRepository;
    }

    public async Task<Result<GetPurchaseResponsesNotInWorkByBuyerIdResponse>> Handle(GetPurchaseResponsesNotInWorkByBuyerIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseResponses =
            await _purchaseResponseRepository.GetNotInWorkByBuyerId(request.BuyerId, cancellationToken);
        return Result.Ok(new GetPurchaseResponsesNotInWorkByBuyerIdResponse(purchaseResponses));
    }
}