namespace TradingPlatformHackathon.DTOs;

public record ChatInfoDto(
    long CompanionId,
    string CompanionName,
    string LatestMessage,
    DateTime LatestMessageTime,
    bool IsLatestMessageRead
    );