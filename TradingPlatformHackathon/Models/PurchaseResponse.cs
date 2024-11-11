using TradingPlatformHackathon.DTOs;

namespace TradingPlatformHackathon.Models;

public class PurchaseResponse
{
    public long Id { get; set; }

    public long PurchaseRequestId { get; set; }
    public PurchaseRequest PurchaseRequest { get; set; } = null!;
    
    public long Cost { get; set; }
    public string Comment { get; set; } = "";

    public long SupplierId { get; set; }
    public User Supplier { get; set; } = null!;
}