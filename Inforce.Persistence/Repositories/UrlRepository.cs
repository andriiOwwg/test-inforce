using Inforce.Persistence.Contexts;
using Inforce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories;

public class UrlRepository: IUrlRepository
{
    private PlatformDbContext _DbContext { get; set; }

    public UrlRepository(PlatformDbContext context)
    {
        _DbContext = context;
    }
    
    public async Task CreateUrl(Url url)
    {
        await _DbContext.Urls.AddAsync(url);
    }

    public async Task SaveChanges()
    {
        await _DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid urlId)
    {
        var url =  await GetUrls()
            .Where(url => url.Id == urlId)
            .FirstOrDefaultAsync();

        if (url != null)
        {
            url.Active = false; 
        }
    }
    public IQueryable<Url> GetUrls()
    {
        var result =  _DbContext.Urls;

        return result;
    }
}