namespace TradingPlatformHackathon.DTOs;

public record GetPurchaseRequestsInWorkByBuyerIdDto(
    long PurchaseRequestId,
    string ProductName,
    long PurchaseRequestCost,
    long ProductCount,
    long SupplierId,
    long PurchaseResponseId,
    long PurchaseResponseCost,
    string Comment
);