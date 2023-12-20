using Microsoft.EntityFrameworkCore;
using UserManyToManyAPI.Data;
using UserManyToManyAPI.Models;

namespace UserManyToManyAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> AddUser(User user)
        {
            await _dataContext.Users.AddAsync(user);
            if (user == null)
                return null;

            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<List<User>> DeleteUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user == null)
                return null;

            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> GetSingleUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user == null)
                return null;

            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var usersWithRoles = await (from user in _dataContext.Users
                                        join userRole in _dataContext.UserRoles
                                        on user.id equals userRole.UserId
                                        join role in _dataContext.Roles
                                        on userRole.RoleId equals role.id
                                        into roles
                                        select new User
                                        {
                                            id = user.id,
                                            Name = user.Name,
                                            Roles = roles.ToList()
                                        }
                                        ).ToListAsync();
            return usersWithRoles;
        }

        public async Task<List<User>> UpdateUser(int id, User user)
        {
            var updatedUser = await _dataContext.Users.FindAsync(id);
            if (updatedUser == null)
                return null;

            updatedUser.Name = user.Name;
            updatedUser.Age = user.Age;
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Users.ToListAsync();
        }
    }
}
