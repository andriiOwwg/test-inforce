namespace Inforce.Shared.Models;

public class UrlCreateModel
{
    public Guid CreatedBy { get; set; }
    
    public string ShortUrl { get; set; }
    
    public string LongUrl { get; set; }
    
    public bool Active { get; set; }
}