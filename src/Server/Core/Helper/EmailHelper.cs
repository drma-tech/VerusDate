using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace VerusDate.Shared.Helper
{
    public class AuthMessageSenderOptions
    {
        public string SendGridKey { get; set; }
        public string SendGridUser { get; set; }
    }

    public class EmailHelper : IEmailSender
    {
        public EmailHelper(IOptions<AuthMessageSenderOptions> options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            this.options = options.Value;
        }

        public AuthMessageSenderOptions options { get; } //set only via Secret Manager

        public async Task<Response> Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@verusdate.com", options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return await client.SendEmailAsync(msg);
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var response = await Execute(options.SendGridKey, subject, htmlMessage, email);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new NotificationException("Could not send email: " + await response.Body.ReadAsStringAsync());
            }
        }
    }
}