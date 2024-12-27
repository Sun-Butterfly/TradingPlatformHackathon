using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetChatInfoByUserId;

public record GetChatInfoByUserIdResponse(List<ChatInfoDto> ChatInfos);