using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using FluentValidation;
using System;
using System.Net;
using System.Data.SqlClient;
using SAIMS.Application.Model;

namespace SAIMS.Application.ExceptionMiddleware;

public class ExceptionMiddleware{
    
    private readonly RequestDelegate _next;        
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _hostEnvironment;
    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment hostEnvironment,
        ILogger<ExceptionMiddleware> logger)
        {
             _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        } 

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(ValidationException  ex)
        {
            await Handle_ValidationExceptionAsync(httpContext, ex); 
        }
        catch(SqlException  ex){
           _logger.LogError($"Something went wrong: {ex}");
            await Handle_SqlExceptionAsync(httpContext, ex); 
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await Handle_ExceptionAsync(httpContext, ex);
        }
    }

    private async Task Handle_SqlExceptionAsync(HttpContext context, SqlException ex)
    {
       context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = "Database Error. Please contact System admin."
        }.ToString());
    }

    private async Task Handle_ExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }

    private async Task Handle_ValidationExceptionAsync(HttpContext context, Exception exception)
    {
        ///Todo
        ///List all errors in message from exception.Errors
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message.ToString()
        }.ToString());
    }

   
    
}
