using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseResponsesNotInWorkByBuyerId;

public record GetPurchaseResponsesNotInWorkByBuyerIdRequest(long BuyerId): IRequest<Result<GetPurchaseResponsesNotInWorkByBuyerIdResponse>>;