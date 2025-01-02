using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(long id, CancellationToken cancellationToken);
    Task<User?> GetByEmailAndPassword(string email, string password, CancellationToken cancellationToken);
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    void Add(User user);
    Task SaveChanges(CancellationToken cancellationToken);
    Task<Dictionary<long, User>> GetByIdMany(IEnumerable<long> userIds, CancellationToken cancellationToken);
}