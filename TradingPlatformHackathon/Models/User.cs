namespace TradingPlatformHackathon.Models;

public class User
{
    public long Id { get; set; }
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    public long RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public List<PurchaseRequest> PurchaseRequestsAsBuyer { get; set; } = new();
    public List<PurchaseRequest> PurchaseRequestsAsSupplier { get; set; } = new();
    public List<PurchaseResponse> PurchaseResponses { get; set; } = new();
}