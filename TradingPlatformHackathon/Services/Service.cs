using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Interfaces;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.Services;

public class Service : IService
{
    private readonly PurchaseRequestRepository _purchaseRequestRepository;

    public Service(PurchaseRequestRepository purchaseRequestRepository)
    {
        _purchaseRequestRepository = purchaseRequestRepository;
    }

    public async Task SetSupplierIdToPurchaseRequest(long purchaseRequestId, long supplierId, CancellationToken cancellationToken)
    {
        var purchaseRequest = await _purchaseRequestRepository.GetById(purchaseRequestId, cancellationToken);
        if (purchaseRequest == null)
        {
            throw new Exception("Запрос на закупку не найден");
        }

        purchaseRequest.SupplierId = supplierId;
        _purchaseRequestRepository.Update(purchaseRequest);
        await _purchaseRequestRepository.SaveChanges(cancellationToken);
    }
}