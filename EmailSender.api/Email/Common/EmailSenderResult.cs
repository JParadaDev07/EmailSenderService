using EmailSender.api.Entities;

namespace EmailSender.api.Email.Common;

public record EmailSenderResult(UserEmail Email, string Message);