using Pharmacy_Management___Sales_API.DTO.DtoUsers;

namespace Pharmacy_Management___Sales_API.Servies.UserServies
{
    public interface ISUserServies
    {
        public Task<UserDtoCreatAccountReplay> AddNewUser(UserDtoCreatAccount user);
        public   Task<UserLoginReplay> SignIn(UserLogin user);
        public   Task<String> RemoveUser(int id);
        public Task<String> UpdateUser(UpDateUser user, int id);
        public Task<RefreshTokenResponse> RefreshToken(RefreshTokenDto dto);
        public Task<List<GetAllUser>> getAllUser();
    }
}
