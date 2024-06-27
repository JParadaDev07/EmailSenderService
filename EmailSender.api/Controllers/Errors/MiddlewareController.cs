using Microsoft.AspNetCore.Mvc;

namespace EmailSender.api.Controllers.Errors;

public class MiddlewareController : ApiController
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}