using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.DeletePurchaseResponse;

public record DeletePurchaseResponseRequest(long PurchaseResponseId) : IRequest<Result<DeletePurchaseResponseResponse>>;