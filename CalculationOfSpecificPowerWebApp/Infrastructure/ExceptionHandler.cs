using Microsoft.AspNetCore.Diagnostics;

namespace CalculationOfSpecificPowerWebApp.Infrastructure
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken token
            )
        {
            _logger.LogError("Произошла ошибка в {method}: {path}. Текст ошибки: {errorMessage}",
                context.Request.Method, context.Request.Path, exception.Message
                );

            //если клиент прервал запрос, то не отправляю ответ
            if (token.IsCancellationRequested)
            {
                return false;
            }

            //устанавливаю кодировку страницы для понятного ответа на русском языке
            context.Response.ContentType = "text/plain; charset=utf-8";

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new {Message = "Что-то пошло не так"});

            return true;
        }
    }
}
