namespace SAIMS.Application.Interfaces;

public interface IJwtUtilsService{
    public Task<DtoToken> GenerateJwtToken(DTOUser user);
    public RefreshToken GenerateRefreshToken();
    public int? ValidateJwtToken(string? token);
}