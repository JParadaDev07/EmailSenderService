using System.Net;
using System.Net.Mail;
using EmailSender.api.Common.Others.Implementation.Interfaces;
using EmailSender.api.Common.Others.Implementation.Settings;
using Microsoft.Extensions.Options;

namespace EmailSender.api.Common.Others.Implementation.Sender;

public class EmailSenderService : IEmailSender
{
    private readonly EmailSettings _emailSettings;

    public EmailSenderService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendEmailAsync(string To, string Subject, string Body)
    {
        var email = new MailMessage
        {
            From = new MailAddress(_emailSettings.Email),
            Subject = Subject,
            Body = Body,
            IsBodyHtml = true
        };

        email.To.Add(To);

        using var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort)
        {
            Credentials = new NetworkCredential
            (_emailSettings.Email, 
            _emailSettings.Password),
            EnableSsl = true
        };

        await client.SendMailAsync(email);

    }

}