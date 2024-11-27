using Container_App.Model.Dto;
using Container_App.Model.Tokens;

namespace Container_App.Services.AuthService
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(string username, string password);
        Task<Token> RefreshToken(string refreshToken);

        Task<List<UserPermission>> GetUserPermissions(int userId);
        Task<bool> HasPermission(int userId, string table, string action);
    }
}
