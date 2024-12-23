using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetAllNotInWorkPurchaseRequests;

public record GetAllNotInWorkPurchaseRequestsRequest() : IRequest<Result<GetAllNotInWorkPurchaseRequestsResponse>>;