using Dapper.Contrib.Extensions;

namespace Inforce.Shared.Entities;

public abstract class BaseEntity
{
    [ExplicitKey]
    public Guid Id { get; set; }

    public DateTime CreationDate { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
}