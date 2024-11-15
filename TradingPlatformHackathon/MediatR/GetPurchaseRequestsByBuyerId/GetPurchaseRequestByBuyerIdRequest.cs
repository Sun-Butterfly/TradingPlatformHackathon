using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestsByBuyerId;

public record GetPurchaseRequestByBuyerIdRequest(long BuyerId) : IRequest<Result<GetPurchaseRequestByBuyerIdResponse>>;