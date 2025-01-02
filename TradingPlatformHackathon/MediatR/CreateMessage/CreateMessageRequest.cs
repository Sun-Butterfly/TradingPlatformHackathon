using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.CreateMessage;

public record CreateMessageRequest(
    long UserId,
    long CompanionId,
    string Text,
    DateTime SendingTime,
    bool IsRead
    ) : IRequest<Result<CreateMessageResponse>>;