namespace Inforce.Shared.Models.DTOs
{
    public class AuthResult
    {
        public string Token { get; set; } = string.Empty;
        public bool Result { get; set; } = false;
        public List<string> Errors { get; set; } = new List<string>();
    }
}