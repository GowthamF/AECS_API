using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private DatabaseContext _databaseContext;

        public OrderController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: api/<OrderController>
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _databaseContext.Orders.ToListAsync();

            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _databaseContext.Orders.Where(x=>x.OrderId == id).FirstOrDefaultAsync();

            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Post([FromBody] Order value)
        {
            await _databaseContext.Orders.AddAsync(value);

            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
