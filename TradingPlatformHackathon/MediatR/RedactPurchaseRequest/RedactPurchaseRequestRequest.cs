using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.RedactPurchaseRequest;

public record RedactPurchaseRequestRequest(
    long PurchaseRequestId,
    string ProductName,
    long ProductCount,
    long Cost
    ) : IRequest<Result<RedactPurchaseRequestResponse>>;