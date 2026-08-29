namespace Pharmacy_Management___Sales_API.DTO.DtoUsers
{
    public class UserDtoCreatAccount
    {
        public string NameUser { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

    }
    public class UserDtoCreatAccountReplay {
        public string Message { get; set; }
    }
}
