using Delivery_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Delivery_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {

        private readonly DatabaseContext _databaseContext;

        public DeliveryController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }



        [HttpGet("GetDelivery/{id}")]
        public async Task<IActionResult> GetDelivery(int id)
        {
            var delivery = await _databaseContext.Deliveries.Where(x=> x.Id == id).FirstOrDefaultAsync();

            return Ok(delivery);
        }


        [HttpPost("CancelDelivery")]
        public async Task<IActionResult> CancelDelivery([FromBody] Delivery delivery)
        {
            await _databaseContext.Deliveries.AddAsync(delivery);

            await _databaseContext.SaveChangesAsync();

            return Ok(delivery);
        }
    }
}
