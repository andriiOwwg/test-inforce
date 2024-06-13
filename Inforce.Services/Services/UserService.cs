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

    public async Task UpdateUser(UserModel userModel)
    {
        var user = _Mapper.Map<User>(userModel);
        await _userRepository.UpdateUser(user);
    }

    public async Task DeleteUser(Guid userId)
    {
        await _userRepository.DeleteUser(userId);
    }

    public async Task<List<UserModel>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        
        return _Mapper.Map<List<UserModel>>(users);
    }
}