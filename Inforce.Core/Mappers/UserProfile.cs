using AutoMapper;
using Inforce.Shared.Entities;

namespace Inforce.Shared.Mappers;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, User>();
        CreateMap<User, UserModel>();
    }
}
