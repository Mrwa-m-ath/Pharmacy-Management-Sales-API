using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.DTO.DtoUsers;
using Pharmacy_Management___Sales_API.Model;
using Pharmacy_Management___Sales_API.Resposter;
using Pharmacy_Management___Sales_API.Servies.UserServies;

namespace Pharmacy_Management___Sales_API.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISUserServies servies;

        public UserController(ISUserServies servies)
        {
            this.servies = servies;
        }
        [HttpPost("RefreshToken")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenDto refresh)
        {
            var result = await servies.RefreshToken(refresh);
            return Ok(new  Compabel<RefreshTokenResponse>
            {

                satas = "Success",
                t = result,
                success = true
            });
        }
        [HttpPost ]
        public async Task<ActionResult> AddUser([FromBody]UserDtoCreatAccount user)
        {
            var result = await servies.AddNewUser(user);
            return  StatusCode(StatusCodes.Status201Created,new Compabel<UserDtoCreatAccountReplay>
            {

                satas = "Success",
                t= result,
                success = true
            });
        }
        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn([FromBody]UserLogin user)
        { 
            var result = await servies.SignIn(user);
            return Ok(new Compabel<UserLoginReplay>
            {

                satas = "Success",
                t = result,
                success = true
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete([FromRoute]int Id)
        {
           await servies.RemoveUser(Id);
            return NoContent(); 
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateUser([FromBody] UpDateUser user, [FromRoute] int Id)
        {
            var result = await servies.UpdateUser(user,Id);
            return Ok(new Compabel<object>
            {

                satas = "Success",
                t = result,
                success = true
            });
        }
        [HttpGet("GetAllUser")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> GetAllUser()
        {
            var result = await  servies.getAllUser();
            return Ok(new Compabel<object>
            {
                satas = "Success",
                success = true,
                t = result
            });
        }
    }
}
