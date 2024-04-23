using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEMailSender
    {
        public EmailSettings EmailSeetings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            EmailSeetings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(EmailSeetings.ApiKey);
            var to = new EmailAddress(email.To);

            var from = new EmailAddress()
            {
                Email = EmailSeetings.FromAddress,
                Name = EmailSeetings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}
