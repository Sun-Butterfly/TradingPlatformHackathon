using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

public class PurchaseResponseRepository : IPurchaseResponseRepository
{
    private readonly DataBaseContext _db;

    public PurchaseResponseRepository(DataBaseContext db)
    {
        _db = db;
    }

    public async Task DeleteByPurchaseRequestId(long id, CancellationToken cancellationToken)
    {
        await _db.PurchaseResponses.Where(x => x.PurchaseRequestId == id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<PurchaseResponse?> GetById(long id, CancellationToken cancellationToken)
    {
        return await _db.PurchaseResponses.FirstOrDefaultAsync(x => x.Id == id,
            cancellationToken: cancellationToken);
    }
    
    public void Add(PurchaseResponse purchaseResponse)
    {
        _db.Add(purchaseResponse);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsById(long id, CancellationToken cancellationToken)
    {
        return await _db.PurchaseResponses.AnyAsync(x => x.Id == id,
            cancellationToken: cancellationToken);
    }

    public async Task DeleteById(long id, CancellationToken cancellationToken)
    {
        await _db.PurchaseResponses.Where(x => x.Id == id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<GetPurchaseResponsesByBuyerIdDto>> GetNotInWorkByBuyerId(long id, CancellationToken cancellationToken)
    {
        return await _db.PurchaseResponses
            .Where(x => x.PurchaseRequest.BuyerId == id && x.PurchaseRequest.SupplierId==null)
            .Select(x => new GetPurchaseResponsesByBuyerIdDto(
                x.Id,
                x.PurchaseRequestId,
                x.Cost,
                x.Comment)).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<GetPurchaseResponsesBySupplierIdDto>> GetBySupplierId(long id, CancellationToken cancellationToken)
    {
        return await _db.PurchaseResponses
            .Where(x => x.SupplierId == id)
            .Select(x => new GetPurchaseResponsesBySupplierIdDto(
                x.Id,
                x.PurchaseRequestId,
                x.Cost,
                x.Comment)).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<GetPurchaseResponsesInWorkBySupplierIdDto>> GetInWorkBySupplierId(long id, CancellationToken cancellationToken)
    {
        return await _db.PurchaseResponses
            .Where(x => x.SupplierId == id && x.PurchaseRequest.SupplierId != null)
            .Select(x => new GetPurchaseResponsesInWorkBySupplierIdDto(
                x.Id,
                x.Cost,
                x.Comment,
                x.PurchaseRequestId,
                x.PurchaseRequest.ProductName,
                x.PurchaseRequest.Cost,
                x.PurchaseRequest.ProductCount,
                x.PurchaseRequest.BuyerId)).ToListAsync(cancellationToken: cancellationToken);
    }
}