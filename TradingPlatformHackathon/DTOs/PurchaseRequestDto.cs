namespace TradingPlatformHackathon.DTOs;

public record PurchaseRequestDto(
    string ProductName,
    long ProductCount,
    long Cost,
    long BuyerId
);
