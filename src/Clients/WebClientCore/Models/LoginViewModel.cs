namespace WebClient.Models
{
    public class LoginViewModel
    {
        public bool HasInvalidAccess { get; set; }
        public string ReturnBaseUrl { get; set; }
        public Login Login { get; set; }
    }
}