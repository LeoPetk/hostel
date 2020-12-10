using System;
using System.Net;
using System.Threading.Tasks;
using Hostel.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Hostel.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
                throw;
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {
            var exceptionType = exception.GetType();
            var message = exception.Message;
            HttpStatusCode statusCode;

            switch (exception)
            {
                case { } e when exceptionType == typeof(BadRequestException):
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            var response = JsonConvert.SerializeObject(new {StatusCode = statusCode, Message = message});

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) statusCode;

            await context.Response.WriteAsync(response);
        }
    }
}