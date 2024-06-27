namespace EmailSender.api.Common.Contracs.Requests;

public record EmailSenderRequest
(
    string To,
    string Subject,
    string Body
);