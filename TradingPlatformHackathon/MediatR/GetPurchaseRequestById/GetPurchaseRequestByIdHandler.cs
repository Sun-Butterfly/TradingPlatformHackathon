using FluentResults;
using MediatR;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestById;

public class GetPurchaseRequestByIdHandler : IRequestHandler<GetPurchaseRequestByIdRequest, Result<GetPurchaseRequestByIdResponse>>
{
    private readonly IPurchaseRequestRepository _purchaseRequestRepository;

    public GetPurchaseRequestByIdHandler(IPurchaseRequestRepository purchaseRequestRepository)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
    }

    public async Task<Result<GetPurchaseRequestByIdResponse>> Handle(GetPurchaseRequestByIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseRequest = await _purchaseRequestRepository.GetDtoById(request.PurchaseRequestId, cancellationToken);
        if (purchaseRequest is null)
        {
            return Result.Fail("Заявка не найдена.");
        }
        return Result.Ok(new GetPurchaseRequestByIdResponse(purchaseRequest));
    }
}