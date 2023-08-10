﻿using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace SuficienciaWebII.Exceptions
{
    public static class GlobalExceptionHandler
    {
        public static async Task Handle(HttpContext context)
        {
            var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (exceptionHandlerFeature == null)
                return;

            var statusCode = exceptionHandlerFeature.Error switch
            {
                EntidadeNaoEncontradaException => HttpStatusCode.NotFound,
                ValidacaoException => HttpStatusCode.UnprocessableEntity,
                _ => HttpStatusCode.InternalServerError,
            };

            context.Response.StatusCode = (int) statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = exceptionHandlerFeature.Error.Message,
            });
        }
    }
}