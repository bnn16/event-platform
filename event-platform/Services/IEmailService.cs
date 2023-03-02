using System.Threading.Tasks;

namespace event_platform
{
    public interface IEmailService
    {
        Task SendAsync(string from, string to, string subject, string body);
    }
}