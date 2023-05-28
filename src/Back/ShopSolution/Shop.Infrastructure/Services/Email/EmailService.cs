using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Models.Mail;

namespace Shop.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        public SendGridSetting SendGridSetting { get; }
        public ILogger<EmailService> Logger { get; }

        public EmailService(IOptions<SendGridSetting> options, ILogger<EmailService> logger)
        {
            SendGridSetting = options.Value;
            Logger = logger;
        }

        public async Task<bool> SendEmailAsync(MailRequest mailRequest, string token)
        {
            try
            {
                var client = new SendGridClient(SendGridSetting.ApiSecret);

                var from = new EmailAddress(SendGridSetting.Email);
                var subject = mailRequest.Subject;
                var to = new EmailAddress(mailRequest.To, mailRequest.To);

                var htmlContent = $"{mailRequest.Body} {SendGridSetting.BaseUrl}/password/reset/{token}";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);

                var response = await client.SendEmailAsync(msg);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                Logger.LogError("Error : Email not send");
                return false;
            }
        }
    }
}
