using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsNotInWorkByBuyerId;

public record GetPurchaseRequestNotInWorkByBuyerIdResponse(List<GetPurchaseRequestByBuyerIdDto> PurchaseRequests);