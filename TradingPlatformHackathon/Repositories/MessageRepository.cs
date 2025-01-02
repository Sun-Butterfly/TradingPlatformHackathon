using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

class MessageRepository : IMessageRepository
{
    private readonly DataBaseContext _db;

    public MessageRepository(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<List<ChatGrouping>> GetChatGroupsByUserId(long userId, CancellationToken cancellationToken)
    {
        return await _db.Messages
            .Where(x => x.SenderId == userId || x.RecipientId == userId)
            .GroupBy(x => new { x.SenderId, x.RecipientId })
            .Select(x => new ChatGrouping(
                x.Key.SenderId,
                x.Key.RecipientId,
                x.OrderByDescending(y => y.SendingTime).FirstOrDefault()
            ))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<GetMessagesByUserAndCompanionIdsDto>> GetMessagesByUserAndCompanionIds(long userId,
        long companionId, CancellationToken cancellationToken)
    {
        return await _db.Messages
            .Where(x => (x.SenderId == userId && x.RecipientId == companionId) ||
                        (x.SenderId == companionId && x.RecipientId == userId))
            .OrderBy(y => y.SendingTime)
            .Select(x => new GetMessagesByUserAndCompanionIdsDto(
                x.SenderId == userId ? userId : companionId,
                x.RecipientId == userId ? userId : companionId,
                x.Text,
                x.SendingTime,
                x.IsRead))
            .ToListAsync(cancellationToken);
    }

    public async Task SetRead(long userId, long companionId, CancellationToken cancellationToken)
    {
        var messages = await _db.Messages
            .Where(x => x.SenderId == companionId && x.RecipientId == userId).ToListAsync(cancellationToken);
        foreach (var message in messages)
        {
            message.IsRead = true;
        }

        await _db.SaveChangesAsync(cancellationToken);
    }

    public void Add(Message message)
    {
        _db.Add(message);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }
}