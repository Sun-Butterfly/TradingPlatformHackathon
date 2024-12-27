namespace TradingPlatformHackathon.Models;

public class Message
{
    public long Id { get; set; }
    public string Text { get; set; } = null!;
    public DateTime SendingTime { get; set; }
    public bool IsRead { get; set; }

    public long SenderId { get; set; }
    public User Sender { get; set; } = null!;

    public long RecipientId { get; set; }
    public User Recipient { get; set; } = null!;
}