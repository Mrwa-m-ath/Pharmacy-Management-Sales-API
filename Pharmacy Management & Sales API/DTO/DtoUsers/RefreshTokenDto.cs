namespace Pharmacy_Management___Sales_API.DTO.DtoUsers
{
    public class RefreshTokenDto
    {
        public DateTime Expired { get; set; }
  
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
    public class RefreshTokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
