using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.DTO.SaleDto;
using Pharmacy_Management___Sales_API.Servies.SaleServies;

namespace Pharmacy_Management___Sales_API.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleServies saleServies;

        public SaleController(ISaleServies saleServies)
        {
            this.saleServies = saleServies;
        }
        [HttpPost("AddSale")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> AddNewSale([FromBody]AddSaleDto add)
        {
            var result = await saleServies.AddNewSale(add);
            return Ok(new Compabel<object>
            {
                satas="Success",
                success=true,
                t= result
            }  );
        }
        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveSale([FromRoute]int Id)
        {
            var result = await saleServies.Remove(Id);
            return Ok(new Compabel<object>
            {
                satas = "Success",
                success = true,
                t = result
            });
        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateSaleDto update, [FromRoute] int Id)
        {
            var result = await saleServies.UpdateAsync(update, Id);
            return Ok(new Compabel<object>
            {
                satas = "Success",
                success = true,
                t = result
            });
        }
        [HttpGet("GetAllSale")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAllSales()
        {
            var result = await saleServies.GetAllSale();
            return Ok(new Compabel<object>
            {
                satas = "Success",
                success = true,
                t = result
            });
        }
    }
}
