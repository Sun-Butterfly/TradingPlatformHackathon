using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesBySupplierId;

public class GetPurchaseResponsesBySupplierIdHandler : IRequestHandler<GetPurchaseResponsesBySupplierIdRequest, Result<GetPurchaseResponsesBySupplierIdResponse>>
{
    private readonly PurchaseResponseRepository _purchaseResponseRepository;

    public GetPurchaseResponsesBySupplierIdHandler(PurchaseResponseRepository purchaseResponseRepository)
    {
        _purchaseResponseRepository = purchaseResponseRepository;
    }

    public async Task<Result<GetPurchaseResponsesBySupplierIdResponse>> Handle(GetPurchaseResponsesBySupplierIdRequest request, CancellationToken cancellationToken)
    {
        var purchaseResponses =
            await _purchaseResponseRepository.GetBySupplierId(request.SupplierId, cancellationToken);
        return Result.Ok(new GetPurchaseResponsesBySupplierIdResponse(purchaseResponses));
    }
}