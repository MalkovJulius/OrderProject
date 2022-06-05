using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OrderProject.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderProject.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(httpContext,
                                           HttpStatusCode.NotFound,
                                           ex.Message,
                                           "Not found");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext,
                                           HttpStatusCode.InternalServerError,
                                           ex.Message,
                                           "Internal server error");
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext,
                                                HttpStatusCode httpStatusCode,
                                                string exMessage,
                                                string message)
        {
            _logger.LogError(exMessage);

            var response = httpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            var errorDto = new ErrorDto()
            {
                Message = message,
                StastusCode = (int)httpStatusCode
            };

            var result = JsonSerializer.Serialize(errorDto);

            await response.WriteAsync(result);
        }
    }
}
