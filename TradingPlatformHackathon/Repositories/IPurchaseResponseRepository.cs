using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

public interface IPurchaseResponseRepository
{
    Task DeleteByPurchaseRequestId(long id, CancellationToken cancellationToken);
    Task<PurchaseResponse?> GetById(long id, CancellationToken cancellationToken);
    void Add(PurchaseResponse purchaseResponse);
    Task SaveChanges(CancellationToken cancellationToken);
    Task<bool> ExistsById(long id, CancellationToken cancellationToken);
    Task DeleteById(long id, CancellationToken cancellationToken);
    Task<List<GetPurchaseResponsesByBuyerIdDto>> GetNotInWorkByBuyerId(long id, CancellationToken cancellationToken);
    Task<List<GetPurchaseResponsesBySupplierIdDto>> GetBySupplierId(long id, CancellationToken cancellationToken);

    Task<List<GetPurchaseResponsesInWorkBySupplierIdDto>> GetInWorkBySupplierId(long id,
        CancellationToken cancellationToken);
}