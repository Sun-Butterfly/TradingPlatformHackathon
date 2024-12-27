using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.DTOs;

public record ChatGrouping(
    long SenderId,
    long CompanionId,
    Message LatestMessage
);