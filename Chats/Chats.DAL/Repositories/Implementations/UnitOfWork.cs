using Chats.DAL.DataContext;
using Chats.DAL.Models;
using Chats.DAL.Repositories.Interfaces;

namespace Chats.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IRepositoryBase<User> _userRepository;
        private IRepositoryBase<Message> _chatRepository;

        public UnitOfWork(
            AppDbContext dbContext, 
            IRepositoryBase<User> userRepository, 
            IRepositoryBase<Message> chatRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _chatRepository = chatRepository;
        }

        public IRepositoryBase<User> UserRepository
        {
            get 
            {
                _userRepository ??= new RepositoryBase<User>(_dbContext);

                return _userRepository; 
            }
        }

        public IRepositoryBase<Message> ChatRepository
        {
            get 
            {
                _chatRepository ??= new RepositoryBase<Message>(_dbContext);

                return _chatRepository; 
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
