using Container_App.Model.Users;
using Container_App.utilities;

namespace Container_App.Services.UserService
{
    public interface IUserService
    {
        Task<List<Users>> GetUsers(PagedResult page);
        Task<Users> GetUserById(int id);
        Task<int> CreateUser(Users user);
        Task<int> UpdateUser(Users user);
        Task<int> DeleteUser(int id);
        Task<int> CountRecord();
    }
}
