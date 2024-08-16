using ColibriCafe.ECoffe.Backend.Entities.DTOs.Authorization;

namespace ColibriCafe.ECoffe.Backend.Entities.Options;

public class AuthorizationOptions
{
    public const string SectionKey = nameof(AuthorizationOptions);
    public string UserName { get; set; }
    public string Password { get; set; }
    public string SecretKey { get; set; }
    public string ValidAudience { get; set; }
    public string ValidIssuer { get; set; }
    public List<UserDto> Users { get; set; }
}