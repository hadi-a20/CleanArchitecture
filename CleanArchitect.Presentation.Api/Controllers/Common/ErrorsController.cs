using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitect.Presentation.Api.Controllers.Common;


[ApiExplorerSettings(IgnoreApi = true)]
[Route("[Controller]")]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error([FromServices] ILogger<ErrorsController> loger)
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        loger.Log(LogLevel.Critical, exception, "Unhandled exception occured!");

        return Problem(
            statusCode: StatusCodes.Status500InternalServerError,
            title: "An unExpected Error occured!");
    }
}
