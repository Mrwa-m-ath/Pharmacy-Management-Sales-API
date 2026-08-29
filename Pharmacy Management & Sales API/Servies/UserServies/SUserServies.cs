using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.DTO.DtoUsers;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Pharmacy_Management___Sales_API.Servies.UserServies
{
    public class SUserServies : ISUserServies
    {

        private readonly ISResposter<User> resposter;

        private readonly IMapper mapper;
        private readonly JWT jwt;

        public SUserServies(IMapper mapper, IOptions<JWT> jwt, ISResposter<User> resposter)
        {

            this.mapper = mapper;
            this.jwt = jwt.Value;
            this.resposter = resposter;
        }
        private string GenarationToken(User user)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var Card = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Claim = new[]
            {
              new Claim(   ClaimTypes.Role,user.Role),
              new Claim(   ClaimTypes.Name,user.NameUser),
            };
            var Token = new JwtSecurityToken
                (
                issuer: jwt.Issuer, audience: jwt.Audience,
                signingCredentials: Card,
                expires: DateTime.UtcNow.AddMinutes(jwt.Expires),
                claims: Claim
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);

        }
        private string RefrshToken()
        {
            var geq = new byte[32];
            var red = System.Security.Cryptography.RandomNumberGenerator.Create();
            red.GetBytes(geq);
            return Convert.ToBase64String(geq);
        }
        public async Task<UserDtoCreatAccountReplay> AddNewUser(UserDtoCreatAccount user)
        {
            var IsExist = await resposter.IsExist(S => S.Email == user.Email);
            if (IsExist != null)



            {
                throw new InvalidOperationException("The User Is  Exist");
            }
            var NewUser = mapper.Map<User>(user);
            var PassHide = BCrypt.Net.BCrypt.HashPassword(NewUser.Password);
            NewUser.Password = PassHide;
            await resposter.addNewAysnc(NewUser);
            await resposter.SaveAysnc();
            return new UserDtoCreatAccountReplay
            {
                Message = "Success"
            };
        }
        public async Task<UserLoginReplay> SignIn(UserLogin user)
        {
            var IsExist = await resposter.IsExist(S => S.Email == user.Email);
            if (IsExist == null)
            {
                throw new InvalidOperationException("The User Is'n Exist");
            }
            var Verify = BCrypt.Net.BCrypt.Verify(user.Password, IsExist.Password);
            if (!Verify)
            {
                throw new InvalidOperationException("The Password worng Exist");            }
            var Token = GenarationToken(IsExist);
            var RefreshTok = RefrshToken();
            IsExist.Token = Token;
            IsExist.RefreshToken = RefreshTok;
            IsExist.Expired = DateTime.UtcNow.AddDays(7);
            await resposter.SaveAysnc();
            return new UserLoginReplay
            {
                Token = IsExist.Token,
                RefreshToken = IsExist.RefreshToken
            };
        }
        public async Task<String> RemoveUser(int id)
        {
            var IsEsist = await resposter.IsExist(S => S.idUser == id);
            if (IsEsist == null)
            {
                throw new InvalidOperationException("The User Is't Exist");
            }
            await resposter.RemoveAysnc(IsEsist);
            await resposter.SaveAysnc();
            return "Success";

        }
        public async Task<String> UpdateUser(UpDateUser user, int id)
        {
            var IsEsist = await resposter.IsExist(S => S.idUser == id);
            if (IsEsist == null)
            {
                throw new InvalidOperationException("The User Is't Exist");
            }
            var NewUpdate = mapper.Map(user, IsEsist);
            await resposter.SaveAysnc();
            return "Success";

        }


        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenDto dto)
        {

            var IsExist = await resposter.IsExist(S => S.RefreshToken == dto.RefreshToken);
            if (IsExist == null)



            {
                throw new InvalidOperationException("The Token Is'n  Exist");
            }
            if (IsExist.Expired <= DateTime.UtcNow)
            {
                throw new InvalidOperationException("The Token Is Expired");
            }
            var newToken = GenarationToken(IsExist);
            var newRefreshToken = RefrshToken();

            IsExist.Token = newToken;
            IsExist.RefreshToken = newRefreshToken;
            IsExist.Expired = DateTime.UtcNow.AddDays(7);

            await resposter.SaveAysnc();

            return new RefreshTokenResponse
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };
        }
        public  async Task<List<GetAllUser>> getAllUser( ) {

            var result = await  resposter.GetAllAsync();
             return result.Select(p => new GetAllUser
            {
              Email=p.Email,
              Gender=p.Gender,
              NameUser=p.NameUser,Role=p.Role
            }).ToList();
 
        }
    }
}
