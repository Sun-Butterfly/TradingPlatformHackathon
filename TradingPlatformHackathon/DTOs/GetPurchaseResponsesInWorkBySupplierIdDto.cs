namespace TradingPlatformHackathon.DTOs;

public record GetPurchaseResponsesInWorkBySupplierIdDto(
    long PurchaseResponseId,
    long PurchaseResponseCost,
    string Comment,
    long PurchaseRequestId,
    string ProductName,
    long PurchaseRequestCost,
    long ProductCount,
    long BuyerId
    );