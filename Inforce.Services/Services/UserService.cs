using AutoMapper;
using Inforce.Shared.Entities;
using Inforce.Shared.Enums;
using WebApplication1.Interfaces;

public class UserService: IUserService
{
    private  IUserRepository _userRepository { get; set; }
    private  IMapper _Mapper { get; set; }

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _Mapper = mapper;
    }

    public async Task CreateUser(UserModel user)
    {
        User newUser = _Mapper.Map<User>(user);
        newUser.AccountStatus = AccountStatus.User;
        newUser.Password = user.Password;
        await _userRepository.CreateUser(newUser);
    }

    public async Task<List<UserModel>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        
        return _Mapper.Map<List<UserModel>>(users);
    }

    public async Task<UserModel> Login(LoginModel login)
    {
        User user = await _userRepository.GetUserByEmail(login.Email);
        
        if (user == null)
        {
            throw new Exception("User not found.");
        }

        if (user.Password != login.Password)
        {
            throw new Exception("Invalid password.");
        }

        return _Mapper.Map<UserModel>(user);
    }
}