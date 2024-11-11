using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Interfaces;

namespace TradingPlatformHackathon.Services;

public class Service : IService
{
    private readonly DataBaseContext _db;

    public Service(DataBaseContext db)
    {
        _db = db;
    }

    public async Task SetSupplierIdToPurchaseRequest(long purchaseRequestId, long supplierId)
    {
        var purchaseRequest = await _db.PurchaseRequests
            .FirstOrDefaultAsync(x => x.Id == purchaseRequestId);
        if (purchaseRequest == null)
        {
            throw new Exception("Запрос на закупку не найден");
        }

        purchaseRequest.SupplierId = supplierId;
        _db.PurchaseRequests.Update(purchaseRequest);
        await _db.SaveChangesAsync();
    }
}