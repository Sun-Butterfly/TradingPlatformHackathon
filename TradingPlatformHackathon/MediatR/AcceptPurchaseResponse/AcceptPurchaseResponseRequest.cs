using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.AcceptPurchaseResponse;

public record AcceptPurchaseResponseRequest(
    long PurchaseResponseId
) : IRequest<Result<AcceptPurchaseResponseResponse>>;
