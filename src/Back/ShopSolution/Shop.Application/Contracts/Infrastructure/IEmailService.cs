using Shop.Application.Models.Mail;

namespace Shop.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(MailRequest mailRequest, string token);
    }
}
