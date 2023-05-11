using Authentication_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authentication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public AuthController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _databaseContext.Users.AddAsync(user);


            await _databaseContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser([FromBody] User user)
        {
            var existingUser = await _databaseContext.Users.Where(x=>x.UserName == user.UserName && x.Password == user.Password).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return Ok(existingUser);
            }

            return StatusCode(500);
        }

    }
}
