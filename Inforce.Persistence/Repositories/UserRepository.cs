using WebApplication1.Interfaces;
using Inforce.Persistence.Contexts;
using Inforce.Shared.Enums;
using Inforce.Shared.Entities;
using Microsoft.EntityFrameworkCore;

public class UserRepository: IUserRepository
{
    private readonly PlatformDbContext _context;

    public UserRepository(PlatformDbContext context)
  {
    _context = context;
  }

   public async Task CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

   public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

   public Task DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetUsers()
    {
        return _context.Users.ToListAsync();
    }
}