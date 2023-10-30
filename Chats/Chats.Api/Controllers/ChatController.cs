using Chats.BLL.DTOs.Responses;
using Chats.BLL.DTOs.Requests;
using Chats.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chats.Api.Controllers
{
    [ApiController]
    [Route("api/chats")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("{receiverId}")]
        public async Task<IEnumerable<ChatMessageResponse>> GetMessagesFromChatAsync(Guid receiverId)
        {
            var currentSenderId = new Guid("c7825ca7-6844-4d33-a8d7-d2f049f99a83");
        
            return await _chatService
                .GetChatHistoryAsync(currentSenderId, receiverId);
        }

        [HttpGet]
        public async Task<IEnumerable<Guid>> GetUsersChatsAsync()
        {
            var currentSenderId = new Guid("c7825ca7-6844-4d33-a8d7-d2f049f99a83");

            return await _chatService.GetUsersChatsAsync(currentSenderId);
        }

        [HttpGet("users/{userId}")]
        public async Task<UserInfoResponse> GetUserInfoAsync(Guid userId)
        {
            return await _chatService.GetUserInfoAsync(userId);
        }

        [HttpPost]
        public async Task AddMessageAsync(AddMessageRequest messageInfo)
        {
            await _chatService.AddMessageToChatAsync(messageInfo);
        }

        [HttpDelete("{receiverId}")]
        public async Task ClearChatHistoryAsync(Guid receiverId)
        {
            var currentSenderId = new Guid("c7825ca7-6844-4d33-a8d7-d2f049f99a83");

            await _chatService.ClearChatHistoryAsync(currentSenderId, receiverId);
        }

        [HttpDelete("remove/{messageId}")] // <- no remove
        public async Task DeleteMessageFromChatAsync(Guid messageId)
        {
            await _chatService.RemoveMessageAsync(messageId);
        }
    }
}
