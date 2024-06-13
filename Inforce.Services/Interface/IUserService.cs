public interface IUserService
{
    Task CreateUser(UserModel userModel);
    Task UpdateUser(UserModel userModel);
    Task DeleteUser(Guid id);
    Task<List<UserModel>> GetUsers();
}