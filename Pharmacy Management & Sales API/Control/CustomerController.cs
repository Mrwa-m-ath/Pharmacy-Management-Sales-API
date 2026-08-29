using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.DTO.CustomerDto;
using Pharmacy_Management___Sales_API.DTO.DtoCategors;
using Pharmacy_Management___Sales_API.Servies.CategoresServies;
using Pharmacy_Management___Sales_API.Servies.CustomerServices;

namespace Pharmacy_Management___Sales_API.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices customer;

        public CustomerController(ICustomerServices customer)
        {
            this.customer = customer;
        }
        [HttpPost("AddCustomerDto")]
        public async Task<ActionResult> AddCustomerDto([FromBody] AddCustomerDto add)
        {
            var result = await customer.AddCustomerDto(add);
            return StatusCode(StatusCodes.Status201Created,

               new Compabel<object>
               {
                   satas = "Success",
                   success = true,
                   t = result

               }
                );
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveCustomer([FromRoute] int id)
        {
              await customer.RemoveCustomer(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateCustomerDto([FromBody] UpdateCustomerDto upDate, [FromRoute] int id)
        {
            var result = await customer.UpdateCustomerDto(upDate, id);
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
