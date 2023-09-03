using Browl.Application.Requests.Mail;
using System.Threading.Tasks;

namespace Browl.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}