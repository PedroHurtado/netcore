using System.Net;
using System.Text.Json;

namespace  api.Controllers;

public class GlobalExceptionMiddleware
{

    private readonly RequestDelegate _next;
    public GlobalExceptionMiddleware(RequestDelegate next){
        this._next = next;
    }
    public record struct MessageRedord(string Message, string Details);
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(NotFoundException ex){
            await HandleNotFoundExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleNotFoundExceptionAsync(HttpContext context, Exception ex)
    {
        
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;       
        
        return context.Response.WriteAsync("");
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        var message = new MessageRedord("ha ocurido un error", ex.Message);       
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(message));
    }
}