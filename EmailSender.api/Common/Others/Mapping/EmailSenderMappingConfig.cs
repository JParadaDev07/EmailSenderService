using EmailSender.api.Common.Contracs.Requests;
using EmailSender.api.Common.Contracts.Responses;
using EmailSender.api.Email.Commands;
using EmailSender.api.Email.Common;
using Mapster;

namespace EmailSender.api.Common.Others.Mapping;

public class EmailSenderMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<EmailSenderRequest, EmailSenderCommand>();
        config.NewConfig<EmailSenderResult, EmailSenderResponse>()
            .Map(dest => dest.To, src => src.Email.To)
            .Map(dest => dest.Subject, src => src.Email.Subject)
            .Map(dest => dest.Body, src => src.Email.Body);

    }
}
