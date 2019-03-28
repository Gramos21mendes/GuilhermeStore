namespace GuilhermeStore.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subjetc, string body);
    }
}