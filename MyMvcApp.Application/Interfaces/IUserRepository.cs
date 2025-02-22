using MyMvcApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByEmail(string email);
    }
}
