using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Interfaces;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.AcceptPurchaseResponse;

public class
    AcceptPurchaseResponseHandler : IRequestHandler<AcceptPurchaseResponseRequest,
        Result<AcceptPurchaseResponseResponse>>
{
    private readonly IService _service;
    private readonly IPurchaseResponseRepository _purchaseResponseRepository;

    public AcceptPurchaseResponseHandler(IService service, IPurchaseResponseRepository purchaseResponseRepository)
    {
        _service = service;
        _purchaseResponseRepository = purchaseResponseRepository;
    }

    public async Task<Result<AcceptPurchaseResponseResponse>> Handle(AcceptPurchaseResponseRequest request,
        CancellationToken cancellationToken)
    {
        var purchaseResponse = await _purchaseResponseRepository.GetById(request.PurchaseResponseId, cancellationToken);
        if (purchaseResponse == null)
        {
            return Result.Fail("Отклик не найден");
        }
        await _service.SetSupplierIdToPurchaseRequest(purchaseResponse.PurchaseRequestId, purchaseResponse.SupplierId, cancellationToken);
        return Result.Ok(new AcceptPurchaseResponseResponse());
    }
}