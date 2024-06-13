using Inforce.Shared.Entities;

namespace WebApplication1.Interfaces;

public interface IUrlRepository
{
    Task CreateUrl(Url url);

    Task SaveChanges();

    Task DeleteAsync(Guid urlId);

    IQueryable<Url> GetUrls();
}