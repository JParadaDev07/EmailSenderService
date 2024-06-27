namespace EmailSender.api.Common.Others.Implementation.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}