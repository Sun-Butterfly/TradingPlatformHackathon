using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetPurchaseRequestById;

public record GetPurchaseRequestByIdRequest(long PurchaseRequestId) : IRequest<Result<GetPurchaseRequestByIdResponse>>;