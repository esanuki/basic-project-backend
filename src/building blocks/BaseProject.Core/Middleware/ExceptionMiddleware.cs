using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseProject.Core.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

            } catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var erro = new
            {
                sucess = false,
                errors = new[] { exception.InnerException.Message }
            };

            var result = new ObjectResult(erro)
            {
                StatusCode = 500

            };

            await result.ExecuteResultAsync(new ActionContext { HttpContext = context });
        }

    }
}
