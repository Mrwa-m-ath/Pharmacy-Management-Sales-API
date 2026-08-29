using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.DTO.DtoCategors;
using Pharmacy_Management___Sales_API.Servies.CategoresServies;

namespace Pharmacy_Management___Sales_API.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoresController : ControllerBase
    {
        private readonly ICategoresServies categores;

        public CategoresController(ICategoresServies categores)
        {
            this.categores = categores;
        }
        [HttpPost("AddCategores")]
     
        public async Task<ActionResult> AddCategores([FromBody]AddCategoresDto add)
        {
            var result = await categores.AddNewCategores(add);
            return Ok(

               new Compabel<object>
               {
                   satas = "Success",
                   success=true,
                   t= result

               }
                );
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> RemoveCatgores([FromRoute] int id)
        {
            var result = await categores.RemoveCatgores(id);
            return Ok(

               new Compabel<object>
               {
                   satas = "Success",
                   success = true,
                   t = result

               }
                );
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateCategores([FromBody] UpDateCategores upDate,[FromRoute] int id)
        {
            var result = await categores.UpdateCategores(upDate, id);
            return Ok(

               new Compabel<object>
               {
                   satas = "Success",
                   success = true,
                   t = result

               }
                );
        }

    }
}
