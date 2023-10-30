namespace Chats.BLL.DTOs.Requests
{
    public class AddMessageRequest
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Text { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;        
    }
}
