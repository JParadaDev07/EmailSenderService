using EmailSender.api.Email.Common;
using ErrorOr;
using MediatR;

namespace EmailSender.api.Email.Commands;

public record EmailSenderCommand
(
    string To,
    string Subject,
    string Body
) : IRequest<ErrorOr<EmailSenderResult>>;