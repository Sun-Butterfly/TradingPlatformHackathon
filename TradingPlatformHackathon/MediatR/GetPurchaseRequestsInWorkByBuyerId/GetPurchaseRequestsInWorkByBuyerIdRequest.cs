using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsInWorkByBuyerId;

public record GetPurchaseRequestsInWorkByBuyerIdRequest(long BuyerId) : IRequest<Result<GetPurchaseRequestsInWorkByBuyerIdResponse>>;