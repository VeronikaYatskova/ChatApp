using Chats.BLL.Services.Implementation;
using Chats.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Chats.BLL.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddServices();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IChatService, ChatService>(); 
        }   
    }
}
