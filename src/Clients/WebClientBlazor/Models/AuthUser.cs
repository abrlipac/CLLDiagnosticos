namespace WebClientBlazor.Models
{
    public static class AuthUser
    {
        public static string UserId { get; set; }
        public static string UserName { get; set; }
        public static string AccessToken { get; set; }
        public static bool isAuthenticated { get; set; } = false;
    }
}
