using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsInWorkByBuyerId;

public record GetPurchaseRequestsInWorkBuBuyerIdRequest(long BuyerId) : IRequest<Result<GetPurchaseRequestsInWorkBuBuyerIdResponse>>;