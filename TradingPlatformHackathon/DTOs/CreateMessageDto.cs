namespace TradingPlatformHackathon.DTOs;

public record CreateMessageDto(
    long CompanionId,
    string Text
);