using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MailKit;
using MimeKit;
using MailKit.Security;


namespace Eventique.Models
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }

    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));
                mail.To.Add(new MailboxAddress("Hello", email));
                mail.Subject = subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = message;
                mail.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.CheckCertificateRevocation = false;
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Connect(_emailSettings.MailServer, _emailSettings.MailPort, SecureSocketOptions.StartTlsWhenAvailable);
                    client.Authenticate("eventiqueminiateam@gmail.com", "#Eventique2020*");
                    client.Send(mail);
                    client.Disconnect(true);
                }

                // Send it...     

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return Task.CompletedTask;
        }

    }
}
