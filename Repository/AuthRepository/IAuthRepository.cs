using Container_App.Model.Tokens;
using Container_App.Model.Users;

namespace Container_App.Repository.AuthRepository
{
    public interface IAuthRepository
    {
        Task<UserModel> GetUserByUsernameAndPassword(string username, string password);
        Task<RefreshTokenModel> GetRefreshToken(string token);
        Task SaveRefreshToken(RefreshTokenModel refreshToken);
        Task RevokeRefreshToken(string token);

        Task<UserModel> GetUserByID(int Id);
    }
}
