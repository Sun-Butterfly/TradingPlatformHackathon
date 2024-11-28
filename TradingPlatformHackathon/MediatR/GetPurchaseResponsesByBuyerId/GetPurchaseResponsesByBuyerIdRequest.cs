using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesByBuyerId;

public record GetPurchaseResponsesByBuyerIdRequest(long BuyerId): IRequest<Result<GetPurchaseResponsesByBuyerIdResponse>>;