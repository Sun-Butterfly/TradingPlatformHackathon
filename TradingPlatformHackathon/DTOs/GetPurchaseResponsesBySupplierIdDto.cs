namespace TradingPlatformHackathon.DTOs;

public record GetPurchaseResponsesBySupplierIdDto(
    long Id,
    long PurchaseRequestId,
    long Cost,
    string Comment
    );