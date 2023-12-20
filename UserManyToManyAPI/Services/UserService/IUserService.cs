using UserManyToManyAPI.Models;

namespace UserManyToManyAPI.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetSingleUser(int id);
        Task<List<User>> AddUser(User user);
        Task<List<User>> DeleteUser(int id);
        Task<List<User>> UpdateUser(int id, User user);
    }
}
