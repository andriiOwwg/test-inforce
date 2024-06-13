using Inforce.Shared.Entities;

namespace WebApplication1.Interfaces;

public interface IUserRepository
{
    Task CreateUser(User user);
    Task<List<User>> GetUsers();
    Task<User> GetUserByEmail(string email);
}