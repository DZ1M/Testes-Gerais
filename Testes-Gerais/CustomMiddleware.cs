using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Testes_Gerais.Services;

namespace Testes_Gerais
{
    public class CustomMiddleware
    {
        //https://www.stevejgordon.co.uk/
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;
        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, GuidService guidService)
        {
            var logMensage = $"Middleware: The GUID from" +
                $" GuidService is {guidService.GetGuid()}";

            _logger.LogInformation(logMensage);

            context.Items.Add("MiddlewareGuid", logMensage);

            await _next(context);
        }
    }
}
