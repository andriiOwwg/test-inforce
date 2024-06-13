using Inforce.Shared.Enums;

public class UserModel
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountStatus? AccountStatus { get; set; }
}

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}