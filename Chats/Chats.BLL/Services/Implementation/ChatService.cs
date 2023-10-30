using AutoMapper;
using Chats.BLL.DTOs.Requests;
using Chats.BLL.DTOs.Responses;
using Chats.BLL.Services.Interfaces;
using Chats.DAL.Models;
using Chats.DAL.Repositories.Interfaces;

namespace Chats.BLL.Services.Implementation
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddMessageToChatAsync(AddMessageRequest messageInfo)
        {
            var message = _mapper.Map<Message>(messageInfo);

            await _unitOfWork.ChatRepository.CreateAsync(message);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ClearChatHistoryAsync(Guid senderId, Guid receiverId)
        {
            var messages = await _unitOfWork.ChatRepository
                .FindAllAsync(c => (c.SenderId == senderId && c.ReceiverId == receiverId) ||
                                   (c.SenderId == receiverId && c.ReceiverId == senderId));

            _unitOfWork.ChatRepository
                .DeleteMultipleEntities(messages);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChatMessageResponse>> GetChatHistoryAsync(Guid senderId, Guid receiverId)
        {
            var messages = await _unitOfWork.ChatRepository
                .FindAllAsync(c => (c.SenderId == senderId && c.ReceiverId == receiverId) ||
                                   (c.SenderId == receiverId && c.ReceiverId == senderId));

            var messagesResponse = _mapper.Map<IEnumerable<ChatMessageResponse>>(messages);

            return messagesResponse;
        }

        public async Task RemoveMessageAsync(Guid messageId)
        {
            var message = await _unitOfWork.ChatRepository
                .FindByConditionAsync(c => c.Id == messageId);

            if (message is null)
            {
                throw new ArgumentNullException("Message is not found!");
            }
            
            _unitOfWork.ChatRepository.Delete(message);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
