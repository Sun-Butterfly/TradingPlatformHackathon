using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

public interface IPurchaseRequestRepository
{
    Task<bool> ExistsById(long id, CancellationToken cancellationToken);
    Task DeleteById(long id, CancellationToken cancellationToken);
    void Add(PurchaseRequest purchaseRequest);
    Task SaveChanges(CancellationToken cancellationToken);
    Task<List<GetPurchaseRequestDto>> GetAllNotInWork(CancellationToken cancellationToken);
    Task<List<GetPurchaseRequestByBuyerIdDto>> GetNotInWorkByBuyerId(long id, CancellationToken cancellationToken);
    Task<List<GetPurchaseRequestsInWorkByBuyerIdDto>> GetInWorkByBuyerId(long id, CancellationToken cancellationToken);
    Task<PurchaseRequest?> GetById(long id, CancellationToken cancellationToken);
    void Update(PurchaseRequest purchaseRequest);
}