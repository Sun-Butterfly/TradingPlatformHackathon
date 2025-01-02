using FluentResults;
using MediatR;
using TradingPlatformHackathon.DTOs;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.GetChatInfoByUserId;

public class
    GetChatInfoByUserIdHandler : IRequestHandler<GetChatInfoByUserIdRequest, Result<GetChatInfoByUserIdResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageRepository _messageRepository;

    public GetChatInfoByUserIdHandler(IUserRepository userRepository, IMessageRepository messageRepository)
    {
        _userRepository = userRepository;
        _messageRepository = messageRepository;
    }

    public async Task<Result<GetChatInfoByUserIdResponse>> Handle(GetChatInfoByUserIdRequest request,
        CancellationToken cancellationToken)
    {
        var chatGroups = await _messageRepository.GetChatGroupsByUserId(request.UserId, cancellationToken);

        var distinctUserIds = chatGroups
            .Select(x => x.SenderId)
            .Concat(chatGroups
                .Select(x => x.CompanionId))
            .Distinct();

        var users = await _userRepository.GetByIdMany(distinctUserIds, cancellationToken);

        var hashset = new HashSet<long>();

        var chats = new Dictionary<long, ChatInfoDto>();
        
        foreach (var currentChatGroup in chatGroups)
        {
            var chattingWith = currentChatGroup.SenderId == request.UserId ? currentChatGroup.CompanionId : currentChatGroup.SenderId;
            if (!hashset.Add(chattingWith))
            {
                if (chats[chattingWith].LatestMessageTime >= currentChatGroup.LatestMessage.SendingTime)
                {
                    continue;   
                }
            }
            
            var info = new ChatInfoDto(
                chattingWith,
                users[chattingWith].Name,
                currentChatGroup.LatestMessage.Text,
                currentChatGroup.LatestMessage.SendingTime,
                currentChatGroup.LatestMessage.IsRead
            );
            chats[chattingWith] = info;
        }

        return Result.Ok(new GetChatInfoByUserIdResponse(chats.Values.ToList()));
    }
}