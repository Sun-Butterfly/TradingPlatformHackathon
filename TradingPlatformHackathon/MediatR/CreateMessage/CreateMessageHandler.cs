using FluentResults;
using MediatR;
using TradingPlatformHackathon.Models;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.CreateMessage;

public class CreateMessageHandler : IRequestHandler<CreateMessageRequest, Result<CreateMessageResponse>>
{
    private readonly IMessageRepository _messageRepository;

    public CreateMessageHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Result<CreateMessageResponse>> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var message = new Message()
        {
            SenderId = request.UserId,
            RecipientId = request.CompanionId,
            Text = request.Text,
            SendingTime = request.SendingTime,
            IsRead = request.IsRead
        };
        _messageRepository.Add(message);
        await _messageRepository.SaveChanges(cancellationToken);
        return Result.Ok(new CreateMessageResponse());
    }
}