
using Microsoft.AspNetCore.Http;
using SAIMS.Application.Interfaces;

namespace SAIMS.Application.JwtMiddleware;

public class JwtMiddleware{
    private readonly RequestDelegate _next;
    
    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context,IJwtUtilsService jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateJwtToken(token);
        if(userId == null)
            throw new UnauthorizedAccessException();
        else
        {
            //context.Items["User"] = userService.GetById(userId.Value);
        }
        await _next(context);
    }
}