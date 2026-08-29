using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Pharmacy_Management___Sales_API.Configration;
using Pharmacy_Management___Sales_API.DTO.DtoProduct;
using Pharmacy_Management___Sales_API.Servies.ProductsServies;

namespace Pharmacy_Management___Sales_API.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductsServies products;

        public ProductController(IProductsServies products)
        {
            this.products = products;
        }

        [HttpPost ]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddProduct([FromBody] AddDtoProduct add)
        {
            var result = await products.AddNewProduct(add);
            return StatusCode(StatusCodes.Status201Created, new Compabel<object>
            {
                satas = "Success",
                success = true,
                t = result
            });


        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAysnc( [FromBody]UpdateProduct update, [FromRoute] int id)
        {
            var result = await products.UpdateAysnc(update,id);
            return Ok(new Compabel<object>
            {
                satas = "Success",
                success = true,
                t = result
            });
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RemoveAysnc(  [FromRoute] int id)
        {
            await products.RemoveAysnc(  id);
            return NoContent();
        }
    }
}
