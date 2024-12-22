using Microsoft.EntityFrameworkCore;

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
}