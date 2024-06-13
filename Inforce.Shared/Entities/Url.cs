using Microsoft.AspNetCore.Http.HttpResults;

namespace Inforce.Shared.Entities;

public class Url: BaseEntity
{
    public Guid CreatedBy { get; set; }
    
    public string ShortUrl { get; set; }
    
    public string LongUrl { get; set; }
    
    public bool Active { get; set; }
}