namespace ClassifiedAds.Models
{
    public class AuthCookieUser
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        //public string PictureUrl { get; set; }
        public string Token { get; set; } = Path.GetRandomFileName();
        public DateTime ValidUpto { get; set; }
    }

    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
