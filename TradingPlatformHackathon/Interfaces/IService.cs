namespace TradingPlatformHackathon.Interfaces;

public interface IService
{
    public Task SetSupplierIdToPurchaseRequest(long purchaseRequestId, long supplierId);
}