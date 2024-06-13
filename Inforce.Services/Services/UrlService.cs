using AutoMapper;
using Inforce.Services.Interface;
using Inforce.Shared.Entities;
using Inforce.Shared.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;

namespace Inforce.Services.Services;

public class UrlService: IUrlService
{
    private IUrlRepository  _urlRepository { get; set; }
    
    public IMapper _Mapper { get; set; }

    public UrlService(IUrlRepository urlRepository,
        IMapper mapper)
    {
        _urlRepository = urlRepository;
        _Mapper = mapper;
    }


    public async Task CreateUrl(UrlCreateModel urlCreateModel)
    {
        var new_url = _Mapper.Map<Url>(urlCreateModel);

        await _urlRepository.CreateUrl(new_url);

        await _urlRepository.SaveChanges();
    }

    public async Task<List<UrlViewModel>> GetUrls()
    {
        var result = await _urlRepository.GetUrls()
            .ToListAsync();
        
        var urlList = _Mapper.Map<List<UrlViewModel>>(result);

        return urlList;

    }

    public async Task DeleteAsync(Guid urlId)
    {
        await _urlRepository.DeleteAsync(urlId);
        
        await _urlRepository.SaveChanges();
    }
}