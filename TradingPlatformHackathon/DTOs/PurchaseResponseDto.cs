namespace TradingPlatformHackathon.DTOs;

public record PurchaseResponseDto(
    long PurchaseRequestId,
    long Cost,
    string Comment
);