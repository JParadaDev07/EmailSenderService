using EmailSender.api.Common.Errors.Factory;
using EmailSender.api.Common.Others.Implementation.Interfaces;
using EmailSender.api.Common.Others.Implementation.Sender;
using EmailSender.api.Common.Others.Mapping;
using EmailSender.api.Email.Behaviors;
using EmailSender.api.Email.Commands;
using EmailSender.api.Email.Common;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EmailSender.api;

public static class Dependencies
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, EmailProblemDetailsFactory>();   
        services.AddSingleton<IEmailSender, EmailSenderService>();
        services.AddMediatR(typeof(Dependencies).Assembly);
        services.AddScoped<IPipelineBehavior<EmailSenderCommand, ErrorOr<EmailSenderResult>>,
            ValidateSendEmailBehavior>();

        services.AddMappings();
        return services;
    }
}