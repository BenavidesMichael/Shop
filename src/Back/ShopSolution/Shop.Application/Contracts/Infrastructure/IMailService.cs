using Shop.Application.Models.Mail;

namespace Shop.Application.Contracts.Infrastructure
{
    public interface IMailService
    {
        Task<bool> SendEmailAsync(MailRequest mailRequest, string token);
    }
}
