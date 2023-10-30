using AutoMapper;
using Chats.BLL.DTOs.Responses;
using Chats.BLL.DTOs.Requests;
using Chats.DAL.Models;

namespace Chats.BLL.Profiles
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<Message, ChatMessageResponse>();
            CreateMap<AddMessageRequest, Message>();
        }
    }
}
