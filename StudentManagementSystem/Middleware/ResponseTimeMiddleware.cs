using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;


namespace StudentManagementSystem.Middleware
{

    public class ResponseTimeMiddleware
    {
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        private readonly RequestDelegate _next;

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext Context)
        {

            var watch = new Stopwatch();
            watch.Start();
            Context.Response.OnStarting(() =>
            {

                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;

                Context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
                return Task.CompletedTask;
            });

            return _next(Context);
        }
    }
}