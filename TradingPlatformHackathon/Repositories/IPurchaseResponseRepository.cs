namespace TradingPlatformHackathon.Repositories;

public interface IPurchaseResponseRepository
{
    Task DeleteByPurchaseRequestId(long id, CancellationToken cancellationToken);
}