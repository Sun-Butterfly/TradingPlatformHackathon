using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _db;

    public UserRepository(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<User?> GetById(long id, CancellationToken cancellationToken)
    {
        return await _db.Users
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAndPassword(string email, string password, CancellationToken cancellationToken)
    {
        return await _db.Users.Include(user => user.Role).FirstOrDefaultAsync(x => x.Email == email &&
                x.Password == password,
            cancellationToken);
    }

    public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Email == email,
            cancellationToken);
    }

    public void Add(User user)
    {
        _db.Add(user);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<Dictionary<long, User>> GetByIdMany(IEnumerable<long> userIds, CancellationToken cancellationToken)
    {
        return await _db.Users
            .Where(x => userIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}