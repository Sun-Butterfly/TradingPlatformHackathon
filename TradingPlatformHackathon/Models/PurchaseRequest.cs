namespace TradingPlatformHackathon.Models;

public class PurchaseRequest
{
    public long Id { get; set; }
    public string ProductName { get; set; } = "";
    public long ProductCount { get; set; }
    public long Cost { get; set; }
    
    public long BuyerId { get; set; }
    public User Buyer { get; set; } = null!;
    
    public long? SupplierId { get; set; }
    public User? Supplier { get; set; }
}