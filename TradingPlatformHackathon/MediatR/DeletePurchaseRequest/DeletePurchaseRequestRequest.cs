using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.DeletePurchaseRequest;

public record DeletePurchaseRequestRequest(long PurchaseRequestId) : IRequest<Result<DeletePurchaseRequestResponse>>;