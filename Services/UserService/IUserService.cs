using Container_App.Model.Users;
using Container_App.utilities;

namespace Container_App.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers(PagedResult page);
        Task<UserModel> GetUserById(int id);
        Task<int> CreateUser(UserModel user);
        Task<int> UpdateUser(UserModel user);
        Task<int> DeleteUser(int id);
    }
}
