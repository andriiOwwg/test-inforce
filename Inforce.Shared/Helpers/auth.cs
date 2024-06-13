namespace Inforce.Shared.Helpers;
class AuthHelper
{
    static string EncryptPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
