using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsNotInWorkByBuyerId;

public record GetPurchaseRequestNotInWorkByBuyerIdRequest(long BuyerId) : IRequest<Result<GetPurchaseRequestNotInWorkByBuyerIdResponse>>;