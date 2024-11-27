using Container_App.Model.Dto;
using Container_App.Model.Tokens;
using Container_App.Model.Users;

namespace Container_App.Repository.AuthRepository
{
    public interface IAuthRepository
    {
        Task<Users> GetUserByUsernameAndPassword(string username, string password);
        Task<RefreshTokenModel> GetRefreshToken(string token);
        Task SaveRefreshToken(RefreshTokenModel refreshToken);
        Task RevokeRefreshToken(string token);

        Task<Users> GetUserByID(int Id);
        Task<List<UserPermission>> GetUserPermissions(int userId);
        Task<bool> HasPermission(int userId, string table, string action);
    }
}
