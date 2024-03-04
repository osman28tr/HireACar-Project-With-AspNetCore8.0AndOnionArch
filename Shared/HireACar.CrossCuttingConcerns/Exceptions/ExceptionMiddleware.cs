using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HireACar.CrossCuttingConcerns.Exceptions
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
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception.GetType() == typeof(BusinessException))
               BusinessExceptionAsync(context, exception);

            else if (exception.GetType() == typeof(NotFoundException))
                NotFoundExceptionAsync(context, exception);

            else if (exception.GetType() == typeof(CustomInternalServerException))
                CustomInternalServerExceptionAsync(context, exception);
            else
                OtherExceptionAsync(context, exception);

            return Task.CompletedTask;
        }
        
        private async Task BusinessExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            context.Response.WriteAsync(new BusinessProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://example.com/probs/business",
                Title = "Business exception",
                Message = exception.Message,
                Instance = ""
            }.ToString());
        }

        private async Task NotFoundExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);

            context.Response.WriteAsync(new BusinessProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = "https://example.com/probs/notfound",
                Title = "NotFound exception",
                Message = exception.Message,
                Instance = ""
            }.ToString());
        }

        private async Task CustomInternalServerExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            context.Response.WriteAsync(new CustomInternalServerExceptionDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/probs/internal",
                Title = "Internal exception",
                Message = exception.Message,
                Instance = ""
            }.ToString());
        }

        private async Task OtherExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            context.Response.WriteAsync(new InternalServerExceptionDetail()
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/probs/internal",
                Title = "Internal exception",
                Detail = exception.Message,
                Instance = ""
            }.ToString());
        }
    }
}
