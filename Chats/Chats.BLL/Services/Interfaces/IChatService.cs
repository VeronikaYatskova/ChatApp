using Chats.BLL.DTOs.Requests;
using Chats.BLL.DTOs.Responses;

namespace Chats.BLL.Services.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<ChatMessageResponse>> GetChatHistoryAsync(Guid senderId, Guid receiverId);
        Task ClearChatHistoryAsync(Guid senderId, Guid receiverId);
        Task AddMessageToChatAsync(AddMessageRequest messageInfo);
        Task RemoveMessageAsync(Guid chatId);
    }
}
