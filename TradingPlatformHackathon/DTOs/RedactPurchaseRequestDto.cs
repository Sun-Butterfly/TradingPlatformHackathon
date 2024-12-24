namespace TradingPlatformHackathon.DTOs;

public record RedactPurchaseRequestDto(
    long PurchaseRequestId,
    string ProductName,
    long ProductCount,
    long Cost
);