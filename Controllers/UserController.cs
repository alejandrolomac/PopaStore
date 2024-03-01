using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopaStore.Data;

namespace PopaStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PopaDBContext _context;

        public UserController(PopaDBContext context)
        {
            _context = context;
        }

        // api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // api/User
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
        }
    }
}
