using Container_App.Model.Tokens;

namespace Container_App.Services.AuthService
{
    public interface IAuthService
    {
        Task<TokenModel> Login(string username, string password);
        Task<TokenModel> RefreshToken(string refreshToken);
    }
}
