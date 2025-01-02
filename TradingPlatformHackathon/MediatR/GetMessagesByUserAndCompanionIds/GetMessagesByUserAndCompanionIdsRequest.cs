using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetMessagesByUserAndCompanionIds;

public record GetMessagesByUserAndCompanionIdsRequest(long UserId, long CompanionId) : IRequest<Result<GetMessagesByUserAndCompanionIdsResponse>>;