using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.CreatePurchaseResponse;

public record CreatePurchaseResponseRequest(
    long PurchaseRequestId,
    long Cost,
    string Comment,
    long SupplierId
) : IRequest<Result<CreatePurchaseResponseResponse>>;