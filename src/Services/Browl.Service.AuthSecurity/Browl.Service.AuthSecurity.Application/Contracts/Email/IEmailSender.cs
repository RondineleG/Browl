using Browl.Service.AuthSecurity.Application.Models.Email;

namespace Browl.Service.AuthSecurity.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
