namespace TradingPlatformHackathon.DTOs;

public record GetPurchaseRequestDto(
    long Id,
    string ProductName,
    long ProductCount,
    long Cost,
    long BuyerId
);
