using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;
using TradingPlatformHackathon.Repositories;

namespace TradingPlatformHackathon.MediatR.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, Result<RegisterResponse>>
{
    private readonly IUserRepository _userRepository;

    public RegisterHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<RegisterResponse>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email, cancellationToken);
        if (user != null)
        {
            return Result.Fail("Пользователь с таким email уже существует!");
        }

        user = new User()
        {
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            RoleId = request.RoleId
        };
        _userRepository.Add(user);
        await _userRepository.SaveChanges(cancellationToken);
        
        return Result.Ok(new RegisterResponse());
    }
}