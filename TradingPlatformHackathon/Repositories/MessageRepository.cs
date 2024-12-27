using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.Repositories;

class MessageRepository : IMessageRepository
{
    private readonly DataBaseContext _db;

    public MessageRepository(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<List<ChatGrouping>> GetChatInfoByUserId(long userId)
    {
        return await _db.Messages
            .Where(x => x.SenderId == userId || x.RecipientId == userId)
            .GroupBy(x => new {x.SenderId, x.RecipientId})
            .Select(x => new ChatGrouping(
                x.Key.SenderId,
                x.Key.RecipientId,
                x.OrderByDescending(y => y.SendingTime).FirstOrDefault()
            ))
            .ToListAsync();
    }
}