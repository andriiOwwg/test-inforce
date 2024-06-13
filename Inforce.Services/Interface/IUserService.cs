public interface IUserService
{
    Task CreateUser(UserModel userModel);
    Task<List<UserModel>> GetUsers();
    Task<UserModel> Login(LoginModel loginModel);
}