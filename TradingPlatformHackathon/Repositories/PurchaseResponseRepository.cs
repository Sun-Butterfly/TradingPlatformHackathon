using Microsoft.EntityFrameworkCore;

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
}