using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

public class PurchaseRequestRepository : IPurchaseRequestRepository
{
    private readonly DataBaseContext _db;

    public PurchaseRequestRepository(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<bool> ExistsById(long id, CancellationToken cancellationToken)
    {
        return await _db.PurchaseRequests.AnyAsync(x => x.Id == id,
            cancellationToken);
    }

    public async Task DeleteById(long id, CancellationToken cancellationToken)
    {
        await _db.PurchaseRequests.Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public void Add(PurchaseRequest purchaseRequest)
    {
        _db.Add(purchaseRequest);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<GetPurchaseRequestDto>> GetAllNotInWork(CancellationToken cancellationToken)
    {
        return await _db.PurchaseRequests.Where(x => x.SupplierId == null)
            .Select(x =>
                new GetPurchaseRequestDto(
                    x.Id,
                    x.ProductName,
                    x.ProductCount,
                    x.Cost,
                    x.BuyerId)).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<GetPurchaseRequestByBuyerIdDto>> GetNotInWorkByBuyerId(long id,
        CancellationToken cancellationToken)
    {
        return await _db.PurchaseRequests
            .Where(x => x.BuyerId == id && x.SupplierId == null)
            .Select(x => new GetPurchaseRequestByBuyerIdDto(
                x.Id,
                x.ProductName,
                x.ProductCount,
                x.Cost)).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<GetPurchaseRequestsInWorkByBuyerIdDto>> GetInWorkByBuyerId(long id,
        CancellationToken cancellationToken)
    {
        return await _db.PurchaseRequests
            .Where(x => x.BuyerId == id && x.SupplierId != null)
            .Include(x => x.PurchaseResponses)
            .SelectMany(x => x.PurchaseResponses!.Select(y => new GetPurchaseRequestsInWorkByBuyerIdDto(
                x.Id,
                x.ProductName,
                x.Cost,
                x.ProductCount,
                y.SupplierId,
                y.Id,
                y.Cost,
                y.Comment))).ToListAsync(cancellationToken);
    }

    public async Task<PurchaseRequest?> GetById(long id, CancellationToken cancellationToken)
    {
        return await _db.PurchaseRequests
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(PurchaseRequest purchaseRequest)
    {
        _db.PurchaseRequests.Update(purchaseRequest);
    }
}