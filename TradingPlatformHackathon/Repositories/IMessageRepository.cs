using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.Repositories;

public interface IMessageRepository
{
    Task<List<ChatGrouping>> GetChatGroupsByUserId(long userId, CancellationToken cancellationToken);

    Task<List<GetMessagesByUserAndCompanionIdsDto>> GetMessagesByUserAndCompanionIds(long userId, long companionId,
        CancellationToken cancellationToken);

    Task SetRead(long userId, long companionId, CancellationToken cancellationToken);
    void Add(Message message);
    Task SaveChanges(CancellationToken cancellationToken);
}