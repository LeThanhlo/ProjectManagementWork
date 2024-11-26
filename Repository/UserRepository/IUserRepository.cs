using Container_App.Model.Users;
using Container_App.utilities;

namespace Container_App.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<Users>> GetUsers(PagedResult page);
        Task<Users> GetUserById(int id);
        Task<int> CreateUser(Users user);
        Task<int> UpdateUser(Users user);
        Task<int> DeleteUser(int id);
        Task<long> CheckAdmin(int userId);
    }
}
