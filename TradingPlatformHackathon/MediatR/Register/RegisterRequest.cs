using FluentResults;
using MediatR;
using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.MediatR.Register;

public record RegisterRequest(
    string Email,
    string Password,
    string Name,
    string Address,
    string PhoneNumber,
    long RoleId
    ) : IRequest<Result<RegisterResponse>>;