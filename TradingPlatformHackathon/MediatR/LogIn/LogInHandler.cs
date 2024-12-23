using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.LogIn;

public class LogInHandler : IRequestHandler<LogInRequest, Result<LogInResponse>>
{
    private readonly UserRepository _userRepository;

    public LogInHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<LogInResponse>> Handle(LogInRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAndPassword(request.Email, request.Password, cancellationToken);
        if (user is null)
        {
            return Result.Fail("Неверный логин или пароль");
        }
        
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeysuperSecretKey@345"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new Claim(type: ClaimTypes.Email, value: request.Email),
            new Claim(type: ClaimTypes.Name,value: user.Name),
            new Claim(type: ClaimTypes.Role, value: user.Role.Name),
            new Claim(type: "Id", value: user.Id.ToString())
        };
        var tokeOptions = new JwtSecurityToken(
            issuer: "https://localhost:5001",
            audience: "https://localhost:5001",
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        
        return Result.Ok(new LogInResponse(tokenString));
    }
}