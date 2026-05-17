using BogeyGolfersWeb.Context;
using BogeyGolfersWeb.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BogeyGolfersWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(BogeyGolfersDbContext context) : ControllerBase
    {
        private readonly BogeyGolfersDbContext _context = context;

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? NotFound() : user;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return _context.Users.Include(u => u.Role).ToList();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                return BadRequest(error: "User Already Exists");
            }
            await _context.Users.AddAsync(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid Values entered for User");
            }
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] User user)
        {
            if (user == null || id < 1)
            {
                return NotFound();
            }
            if (_context.Users.Any(u => u.Username == user.Username && u.Id != id))
            {
                return BadRequest(error: "User Already Exists");
            }
            var existingUser = await _context.Users.FindAsync(id);
            existingUser.Username = user.Username;
            existingUser.Role = user.Role;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid Values entered for User");
            }
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if(User == null || id < 1)
            {
                return NotFound();
            }
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
            return Ok();
        }
    }
}