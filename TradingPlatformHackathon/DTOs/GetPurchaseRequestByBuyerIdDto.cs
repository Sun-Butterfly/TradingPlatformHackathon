namespace TradingPlatformHackathon.DTOs;

public record GetPurchaseRequestByBuyerIdDto(
    long Id,
    string ProductName,
    long ProductCount,
    long Cost
);
