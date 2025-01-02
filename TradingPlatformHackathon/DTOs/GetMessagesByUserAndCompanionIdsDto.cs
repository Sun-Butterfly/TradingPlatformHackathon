namespace TradingPlatformHackathon.DTOs;

public record GetMessagesByUserAndCompanionIdsDto(
    long SenderId,
    long RecipientId,
    string Text,
    DateTime SendingTime,
    bool IsMessageRead
);