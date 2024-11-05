namespace TradingPlatformHackathon.DTOs;

public record RegisterUserRequestDto(
    string Email, 
    string Password, 
    string Name, 
    string Address, 
    string PhoneNumber,
    long RoleId
    );