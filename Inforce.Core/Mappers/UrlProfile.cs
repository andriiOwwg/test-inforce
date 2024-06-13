using AutoMapper;
using Inforce.Shared.Entities;
using Inforce.Shared.Models;

namespace Inforce.Shared.Mappers;

public class UrlProfile: Profile
{
    public UrlProfile()
    {
        CreateMap<UrlCreateModel, Url>();
        CreateMap<Url, UrlCreateModel>();
        CreateMap<UrlViewModel, Url>();
        CreateMap<Url, UrlViewModel>();
    }
}