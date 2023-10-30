namespace Chats.BLL.DTOs.Requests
{
    public class ChatHistoryRequest
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
