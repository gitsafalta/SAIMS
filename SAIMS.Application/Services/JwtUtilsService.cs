using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using SAIMS.Application.Interfaces;
using SAIMS.Application.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Cryptography;

namespace SAIMS.Application.Services;

public class JwtUtilsService : IJwtUtilsService
{
    private readonly AppSettings _appSettings;

    public JwtUtilsService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        if (string.IsNullOrEmpty(_appSettings.secret))
            throw new Exception("JWT secret not configured");
    }

    public async Task<DtoToken> GenerateJwtToken(DTOUser user)
    {
        var signingKey = _appSettings.secret!;
        List<Claim> claim = new List<Claim>(){
          new Claim(ClaimTypes.Name, user.userName!),
          new Claim(ClaimTypes.Role, "admin"),
          new Claim(ClaimTypes.Role,"user")  
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        // Create a payload object that contains the information you want to include in the token
        var payload = new
        {
            iss = _appSettings.issuerName,
            aud = _appSettings.audience,
            exp = DateTime.Now.AddMinutes(1),
            sub = claim
        };
        
        var jwttoken = new JsonWebTokenHandler().CreateToken(System.Text.Json.JsonSerializer.Serialize(payload), creds);
        var refresh_token = GenerateRefreshToken();
        
        //TODO: save referesh token into DB

        var dtotoken = new DtoToken{
            token = jwttoken,
            refreshToken = refresh_token.token,
            expiresIn = DateTime.Now.AddMinutes(10).ToString("yyyy-MM-dd HH:mm:ss"),
            refreshTokenExpiresIn = refresh_token.expiresIn
        };

        return await Task.FromResult(dtotoken);
    }

    public RefreshToken GenerateRefreshToken()
    {
        return new RefreshToken
        {
            token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            expiresIn = DateTime.Now.AddDays(7)
        };
    }

    public int? ValidateJwtToken(string? token)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.secret!);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return null;
        }
    }
}