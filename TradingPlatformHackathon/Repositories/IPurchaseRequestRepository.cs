namespace TradingPlatformHackathon.Repositories;

public interface IPurchaseRequestRepository
{
    Task<bool> ExistsById(long id, CancellationToken cancellationToken);
    Task DeleteById(long id, CancellationToken cancellationToken);
}