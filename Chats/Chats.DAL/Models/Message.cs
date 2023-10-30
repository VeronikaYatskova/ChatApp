namespace Chats.DAL.Models
{
    public class Message
    {
        public Guid Id { get; set; } 
        
        public Guid SenderId { get; set; }
        public User? Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public User? Receiver { get; set; }

        public string Text { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
