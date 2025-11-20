using Betsson.OnlineWallets.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Betsson.OnlineWallets.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SystemController : ControllerBase
    {
        public IActionResult Error()
        {
            IExceptionHandlerPathFeature? exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is InsufficientBalanceException)
            {
                Exception? exception = exceptionHandlerPathFeature?.Error;
                return Problem(exception?.StackTrace, statusCode: 400, title: exception?.Message, type: nameof(InsufficientBalanceException));
            }
                    
            return Problem();
        }
        
    }
}
