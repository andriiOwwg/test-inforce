using Inforce.Shared.Enums;

namespace Inforce.Shared.Entities;

public class User: BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountStatus AccountStatus { get; set; }
}