namespace TradingPlatformHackathon.DTOs;

public record GetPurchaseRequestByIdDto(
    string ProductName,
    long ProductCount,
    long Cost
);