using EmailSender.api.Common.Contracs.Requests;
using EmailSender.api.Common.Contracts.Responses;
using EmailSender.api.Controllers.Errors;
using EmailSender.api.Email.Commands;
using EmailSender.api.Email.Common;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.api.Controllers.Common;

[Route("api")]
public class EmailController(ISender mediator, IMapper mapper) : ApiController
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] EmailSenderRequest request)
    {
        var command = _mapper.Map<EmailSenderCommand>(request);
        ErrorOr<EmailSenderResult> result = await _mediator.Send(command);

        return result.Match
        (
            result => Ok(_mapper.Map<EmailSenderResponse>(result)),
            errors => Problem(errors)
        );
    }
}