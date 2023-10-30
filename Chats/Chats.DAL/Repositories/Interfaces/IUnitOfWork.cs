using Chats.DAL.Models;

namespace Chats.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryBase<User> UserRepository { get; }
        IRepositoryBase<Message> ChatRepository { get; }
        Task SaveChangesAsync();
    }
}
