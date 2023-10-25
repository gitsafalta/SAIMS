using System.Text.Json.Serialization;

namespace SAIMS.Application;

/*public class User{
    public string? refreshToken { get; set; }
    public DateTime tokenCreated { get; set; }
    public DateTime tokenExpires { get; set; }
}*/

public class DTOUser{
    public  required string userName { get; set; }
    public required string password { get; set; }
}

public class DtoToken{
    public string? token { get; set; }

    public string? refreshToken{get; set;}

    public string? expiresIn { get; set; }

    [JsonIgnore]
    public DateTime refreshTokenExpiresIn{get; set;}
}

public class RefreshToken{
    public required string token { get; set; }
    public DateTime created { get; set; } = DateTime.Now;
    public DateTime expiresIn { get; set; }
}