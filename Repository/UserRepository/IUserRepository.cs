using Container_App.Model.Users;
using Container_App.utilities;

namespace Container_App.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetUsers(PagedResult page);
        Task<UserModel> GetUserById(int id);
        Task<int> CreateUser(UserModel user);
        Task<int> UpdateUser(UserModel user);
        Task<int> DeleteUser(int id);
        Task<long> CheckAdmin(int userId);
    }
}
