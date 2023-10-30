namespace ChatApp.Client.Services
{
    public interface IHttpClientServiceImplementation
    {
        Task Execute();
        Task<IEnumerable<Guid>> GetUsersChatExecute();
    }
}
