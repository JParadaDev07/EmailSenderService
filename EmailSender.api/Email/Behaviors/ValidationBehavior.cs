using EmailSender.api.Email.Commands;
using EmailSender.api.Email.Common;
using ErrorOr;
using MediatR;

namespace EmailSender.api.Email.Behaviors;

public class ValidateSendEmailBehavior :
    IPipelineBehavior<EmailSenderCommand, ErrorOr<EmailSenderResult>>
{
    public async Task<ErrorOr<EmailSenderResult>> Handle
    (
        EmailSenderCommand request,
        RequestHandlerDelegate<ErrorOr<EmailSenderResult>> next,
        CancellationToken cancellationToken
    )
    {
        var result = await next();
        return result;
    }
}