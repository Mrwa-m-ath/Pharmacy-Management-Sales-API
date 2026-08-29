using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management___Sales_API.Servies.Details;

namespace Pharmacy_Management___Sales_API.Control
{
    [Route("api/[controller]")]
    [ApiController]
    public class IDetalsController : ControllerBase
    {
        private readonly IDetals detals;

        public IDetalsController(IDetals detals)
        {
            this.detals = detals;
        }
        [HttpGet("SubTotal")]
          public ActionResult SubTotal()
        {
            return Ok(detals.SubTotal());
        }
        [HttpPost("NewStock")]
        public ActionResult NewStock(int id)
        {
            return Ok(detals.NewStock(id));
        }
    }
}
