using FluentResults;
using MediatR;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetMessagesByUserAndCompanionIds;

public class GetMessagesByUserAndCompanionIdsHandler : IRequestHandler<GetMessagesByUserAndCompanionIdsRequest, Result<GetMessagesByUserAndCompanionIdsResponse>>
{
    private readonly IMessageRepository _messageRepository;

    public GetMessagesByUserAndCompanionIdsHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Result<GetMessagesByUserAndCompanionIdsResponse>> Handle(GetMessagesByUserAndCompanionIdsRequest request, CancellationToken cancellationToken)
    {
        var messages =
            await _messageRepository.GetMessagesByUserAndCompanionIds(request.UserId, request.CompanionId,
                cancellationToken);
        
        await _messageRepository.SetRead(request.UserId, request.CompanionId, cancellationToken);
        return Result.Ok(new GetMessagesByUserAndCompanionIdsResponse(messages));
    }
}