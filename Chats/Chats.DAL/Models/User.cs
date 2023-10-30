namespace Chats.DAL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Message>? Chats { get; set; }
    }
}
