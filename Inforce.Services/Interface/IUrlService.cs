using Inforce.Shared.Models;

namespace Inforce.Services.Interface;

public interface IUrlService
{
    Task CreateUrl(UrlCreateModel urlCreateModel); 
    Task<List<UrlViewModel>> GetUrls();

    Task DeleteAsync(Guid urlId);
}