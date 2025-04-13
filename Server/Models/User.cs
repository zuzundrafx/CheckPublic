namespace Server.Models;  // Пространство имён = Server.Models

public class User
{
    public int Id { get; set; }
    public long TelegramId { get; set; }
    public required string Username { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}