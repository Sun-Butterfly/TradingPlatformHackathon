using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TradingPlatformHackathon.Models;

namespace TradingPlatformHackathon.MediatR.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, Result<RegisterResponse>>
{
    private readonly DataBaseContext _db;

    public RegisterHandler(DataBaseContext db)
    {
        _db = db;
    }

    public async Task<Result<RegisterResponse>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == request.Email,
            cancellationToken: cancellationToken);
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
        _db.Add(user);
        await _db.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(new RegisterResponse());
    }
}