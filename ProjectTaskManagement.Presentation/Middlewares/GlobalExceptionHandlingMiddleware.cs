using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Presentation.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode ==
                    (int)HttpStatusCode.Unauthorized)
                {
                    await HandleUnauthorizedAsync(context);
                }
                if (context.Response.StatusCode ==
                  (int)HttpStatusCode.Forbidden)
                {
                    await HandleForbiddenAsync(context);
                    return;
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleUnauthorizedAsync(
            HttpContext context)
        {
            var response = new GenericResponse<string>
            {
                IsSuccess = false,
                Message = "User not signed in",
                StatusCode = HttpStatusCode.Unauthorized
            };

            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                (int)HttpStatusCode.OK;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy =
                    JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(
                response,
                options);

            await context.Response.WriteAsync(json);
        }
        private static async Task HandleForbiddenAsync(
        HttpContext context)
        {
            var response = new GenericResponse<string>
            {
                IsSuccess = false,
                Message = "Access denied",
                StatusCode = HttpStatusCode.Forbidden
            };

            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                (int)HttpStatusCode.OK;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy =
                    JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(
                response,
                options);

            await context.Response.WriteAsync(json);
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception ex)
        {
            var response = new GenericResponse<string>
            {
                IsSuccess = false,
                Message = ex.Message,
                StatusCode = HttpStatusCode.InternalServerError
            };

            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                (int)HttpStatusCode.OK;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy =
                    JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(
                response,
                options);

            await context.Response.WriteAsync(json);
        }
    }
}