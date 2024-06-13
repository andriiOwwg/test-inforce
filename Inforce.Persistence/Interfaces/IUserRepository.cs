using Inforce.Shared.Entities;

namespace WebApplication1.Interfaces;

public interface IUserRepository
{
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(Guid id);

    Task<List<User>> GetUsers();
}