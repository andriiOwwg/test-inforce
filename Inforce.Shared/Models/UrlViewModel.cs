namespace Inforce.Shared.Models;

public class UrlViewModel
{
    public Guid Id { get; set; }

    public DateTime CreationDate { get; set; }
    
    public Guid CreatedBy { get; set; }
    
    public string ShortUrl { get; set; }
    
    public string LongUrl { get; set; }
    
    public bool Active { get; set; }
}