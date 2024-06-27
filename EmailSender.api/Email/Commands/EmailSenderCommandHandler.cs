using EmailSender.api.Common.Others.Implementation.Interfaces;
using EmailSender.api.Email.Common;
using EmailSender.api.Entities;
using EmailSender.api.Entities.Errors;
using ErrorOr;
using MediatR;

namespace EmailSender.api.Email.Commands;

public class MailSenderCommandHandler :
    IRequestHandler<EmailSenderCommand, ErrorOr<EmailSenderResult>>
{
    private readonly IEmailSender _emailSender;

    public MailSenderCommandHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public async Task<ErrorOr<EmailSenderResult>> Handle(
        EmailSenderCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1.- Validate if the user email is empty

        if (string.IsNullOrWhiteSpace(request.To))
        {
            return Errors.Email.EmptyEmail;
        }

        // 2.- Validate if the user domain email is wrongly written
        if (!request.To.Contains('@')
            || !request.To.Contains("gmail")
            || !request.To.Contains('.')
            || !request.To.Contains("com"))
        {
            return Errors.Email.InvalidEmail;
        }

        // 3.- Send the email to the user

        try
        {
            await _emailSender.SendEmailAsync(
                request.To,
                request.Subject,
                request.Body
                );

            // Create a new UserMail object
            UserEmail email = new UserEmail
            {
                To = request.To,
                Subject = request.Subject,
                Body = request.Body
            };

            return new EmailSenderResult
            (
                email,
                "Email sent successfully"
            );

        }
        catch (Exception)
        {
            return Errors.Email.EmailNotSent;
        }

    }

}