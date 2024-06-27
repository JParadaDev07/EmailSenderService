namespace EmailSender.api.Common.Contracts.Responses;

public record EmailSenderResponse
(
    string To,
    string Subject,
    string Body
);