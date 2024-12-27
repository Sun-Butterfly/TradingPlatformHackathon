using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.Repositories;

public interface IMessageRepository
{
    Task<List<ChatGrouping>> GetChatInfoByUserId(long userId);
}