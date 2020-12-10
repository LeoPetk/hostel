using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Hostel.Api.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            try
            {
                await _next.Invoke(context);
                stopWatch.Stop();
            
                LogResponse(context, context.Response.StatusCode, stopWatch);
            }
            
            catch (Exception e) when(LogException(context, stopWatch, e)){}
        }

        private void LogResponse(HttpContext context, int statusCode, Stopwatch stopwatch)
        {
            stopwatch.Stop();
            
            if (statusCode > 399)
            {
                _logger.LogError($"Request: {context.Request.Method}, {context.Request.Path}, Responded: {statusCode} in {stopwatch.Elapsed.TotalMilliseconds} ms");
            }

            if (statusCode < 400)
            {
                _logger.LogInformation($"Request: {context.Request.Method}, {context.Request.Path}, Responded: {statusCode} in {stopwatch.Elapsed.TotalMilliseconds} ms");
            }
        }

        private bool LogException(HttpContext context, Stopwatch stopwatch, Exception exception)
        {
            stopwatch.Stop();
            
            _logger.LogError($"Request: {context.Request.Method}, {context.Request.Path}, Responded: in {stopwatch.Elapsed.TotalMilliseconds} ms, ExceptionMessage: {exception.Message} ,StackTrace: {exception.StackTrace}");

            return false;
        }
    }
}