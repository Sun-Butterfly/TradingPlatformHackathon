using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.CreatePurchaseRequest;

public record CreatePurchaseRequestRequest(
    string ProductName,
    long ProductCount,
    long Cost,
    long BuyerId
) : IRequest<Result<CreatePurchaseRequestResponse>>;