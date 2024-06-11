using Inforce.Shared.Enums;

namespace Inforce.Shared.Entities;

public class User: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserSurname { get; set; }
    public Guid? AccountStatusId { get; set; }
    public virtual AccountStatus AccountStatus { get; set; }
}