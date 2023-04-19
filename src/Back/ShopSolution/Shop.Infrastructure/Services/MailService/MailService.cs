﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Models.Mail;

namespace Shop.Infrastructure.Services.MailService
{
    public class MailService : IMailService
    {
        public SendGridSetting _sendGridSetting { get; }
        public ILogger<MailService> _logger { get; }

        public MailService(IOptions<SendGridSetting> options, ILogger<MailService> logger)
        {
            _sendGridSetting = options.Value;
            _logger = logger;
        }


        public async Task<bool> SendEmailAsync(MailRequest mailRequest, string token)
        {
            try
            {
                var client = new SendGridClient(_sendGridSetting.ApiSecret);
                
                var from = new EmailAddress(_sendGridSetting.Email);
                var subject = mailRequest.Subject;
                var to = new EmailAddress(mailRequest.To, mailRequest.To);
                

                var htmlContent = $"{mailRequest.Body} {_sendGridSetting.BaseUrl}/password/reset/{token}";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);

                var response = await client.SendEmailAsync(msg);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                _logger.LogError("Error : Email not send");
                return false;
            }
        }
    }
}
