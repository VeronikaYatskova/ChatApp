namespace Chats.BLL.DTOs.Responses
{
    public class ChatMessageResponse
    {
        public Guid Id { get; set; } 
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Text { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
