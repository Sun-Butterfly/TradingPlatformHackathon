using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsInWorkByBuyerId;

public record GetPurchaseRequestsInWorkBuBuyerIdResponse(List<GetPurchaseRequestsInWorkByBuyerIdDto> PurchaseRequestsInWork);