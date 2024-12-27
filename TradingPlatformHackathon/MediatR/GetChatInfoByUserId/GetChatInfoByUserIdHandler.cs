using FluentResults;
using MediatR;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetChatInfoByUserId;

public class GetChatInfoByUserIdHandler : IRequestHandler<GetChatInfoByUserIdRequest, Result<GetChatInfoByUserIdResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;

    public GetChatInfoByUserIdHandler(IUserRepository userRepository, IMessageRepository messageRepository)
    {
        _userRepository = userRepository;
        _messageRepository = messageRepository;
    }

    public async Task<Result<GetChatInfoByUserIdResponse>> Handle(GetChatInfoByUserIdRequest request, CancellationToken cancellationToken)
    {
        var chatGroups = await _messageRepository.GetChatInfoByUserId(request.UserId);

        var distinctUserIds = chatGroups.Select(x => x.SenderId).Concat(chatGroups.Select(x => x.CompanionId)).Distinct();

        var users = await _userRepository.GetByIdMany(distinctUserIds);

        var chats = chatGroups.Select(x => new ChatInfoDto(
            x.SenderId == request.UserId ? x.CompanionId : x.SenderId,
            users[x.SenderId == request.UserId ? x.CompanionId : x.SenderId].Name,
            x.LatestMessage.Text,
            x.LatestMessage.SendingTime,
            x.LatestMessage.IsRead
        ));

        return Result.Ok(new GetChatInfoByUserIdResponse(chats.ToList()));
    }
}