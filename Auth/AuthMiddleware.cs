using System.Linq;
using System.Threading.Tasks;
using FoodbWebAPI.Auth;
using FoodbWebAPI.Data;
using Microsoft.AspNetCore.Http;


public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtAuthenticationManager jwtMgr)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtMgr.ValidateToken(token);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetUserById(userId.Value);
        }

        await _next(context);
    }
}