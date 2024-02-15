﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            {
                context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

                return context.Response.WriteAsync(new BusinessProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://example.com/probs/business",
                    Title = "Business exception",
                    Message = exception.Message,
                    Instance = ""
                }.ToString());
            }
            else
            {
                context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

                return context.Response.WriteAsync(new ProblemDetails
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
}