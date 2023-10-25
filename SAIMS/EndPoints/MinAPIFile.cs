
using SAIMS.Application.Interfaces;
using SAIMS.Application.Model;
using SAIMS.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SAIMS.Application;

namespace minAPIFile;

public static class TodoEndpoints
{
    public static void Map(WebApplication app)
    {
         app.MapPost("login",async (IJwtUtilsService _jwtUtilSetice, HttpContext httpContext,DTOUser model) =>{     
            var token = await _jwtUtilSetice.GenerateJwtToken(model);
            var cookieOptions = new CookieOptions{
                HttpOnly = true,
                Expires = token.refreshTokenExpiresIn
            };
            httpContext.Response.Cookies.Append("RefreshToken", token.refreshToken!);
            return token;
        });

        app.MapPost("/refreshtoken", async (IJwtUtilsService _jwtUtilSetice)=>{
            return _jwtUtilSetice.GenerateRefreshToken();
        });

        app.MapPost("/api/sales", async (ISalesService _sales, DTOSalesRequest model)=>{
            return Results.Ok(await _sales.GetTotalSalesDetails(model));
        });

        app.MapGet("/api/discount",async (IDiscountService _discount) =>{
            return Results.Ok(await _discount.GetDiscountDetails());
        });

        app.MapPost("/api/inventory",async (IInventoryService _inventoryService,DTPostModel param) =>{           
            var inventoryList = await _inventoryService.GetInventoryList(param);
            return inventoryList;
        });
    }

}