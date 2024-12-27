using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.GetChatInfoByUserId;

public record GetChatInfoByUserIdRequest(long UserId) : IRequest<Result<GetChatInfoByUserIdResponse>>;