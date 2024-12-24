using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesInWorkBySupplierId;

public class GetPurchaseResponsesInWorkBySupplierIdHandler : IRequestHandler<
    GetPurchaseResponsesInWorkBySupplierIdRequest, Result<GetPurchaseResponsesInWorkBySupplierIdResponse>>
{
    private readonly IPurchaseResponseRepository _purchaseResponseRepository;

    public GetPurchaseResponsesInWorkBySupplierIdHandler(IPurchaseResponseRepository purchaseResponseRepository)
    {
        _purchaseResponseRepository = purchaseResponseRepository;
    }

    public async Task<Result<GetPurchaseResponsesInWorkBySupplierIdResponse>> Handle(
        GetPurchaseResponsesInWorkBySupplierIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseResponsesInWork =
            await _purchaseResponseRepository.GetInWorkBySupplierId(request.SupplierId, cancellationToken);
        return Result.Ok(new GetPurchaseResponsesInWorkBySupplierIdResponse(purchaseResponsesInWork));
    }
}