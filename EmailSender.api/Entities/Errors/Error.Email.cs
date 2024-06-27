using ErrorOr;

namespace EmailSender.api.Entities.Errors;

public static partial class Errors
{
    public static class Email
    {
        public static Error InvalidEmail => Error.Validation
        (
            code: "Email.Invalid",
            description: "The email address is invalid."
        );

        public static Error EmptyEmail => Error.Validation
        (
            code: "Email.Empty",
            description: "You need to put an email address to send data."
        );

        public static Error EmailNotSent => Error.Conflict
        (
            code: "Email.NotSent",
            description: "The email was not sent."
        );
    }
}