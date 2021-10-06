using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServiceClient
{
    public class ExceptionDetailMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionDetailMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // ....

            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var errors = new List<string>();
                var current = e;
                do
                {
                    errors.Add("- " + current.Message);
                    current = current.InnerException;
                } while (current != null);

                errors.Reverse();

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Error processing request",
                    Errors = errors
                });
            }
        }
    }
}
