namespace TradingPlatformHackathon.DTOs;

public record GetPurchaseResponsesByBuyerIdDto(
    long Id,
    long PurchaseRequestId,
    long Cost,
    string Comment
    );