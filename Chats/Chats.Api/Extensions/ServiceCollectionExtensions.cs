using Chats.DAL.Extensions;
using Chats.BLL.Extentions;

namespace Chats.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLayers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBusinessLogicLayer();
            services.AddDataAccessLayer(configuration);
        }
    }
}
