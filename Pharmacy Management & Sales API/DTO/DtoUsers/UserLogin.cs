namespace Pharmacy_Management___Sales_API.DTO.DtoUsers
{
    public class UserLogin
    {
 
        public string Password { get; set; }
 
        public string Email { get; set; }
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
    }
    public class UserLoginReplay
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; } = "";
 
    }
}
