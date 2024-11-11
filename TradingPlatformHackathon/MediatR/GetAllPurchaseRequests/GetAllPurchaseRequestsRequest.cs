using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetAllPurchaseRequests;

public record GetAllPurchaseRequestsRequest() : IRequest<Result<GetAllPurchaseRequestsResponse>>;