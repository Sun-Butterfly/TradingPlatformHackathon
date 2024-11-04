using FluentResults;
using MediatR;

namespace TradingPlatformHackathon.MediatR.LogIn;

public record LogInRequest(string Email, string Password) : IRequest<Result<LogInResponse>>;