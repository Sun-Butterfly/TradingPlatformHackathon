using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.GetMessagesByUserAndCompanionIds;

public record GetMessagesByUserAndCompanionIdsResponse(List<GetMessagesByUserAndCompanionIdsDto> MessagesByUserAndCompanionIds);