using BogeyGolfersWeb.Context;
using BogeyGolfersWeb.models;
using Microsoft.AspNetCore.Mvc;

namespace BogeyGolfersWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController(BogeyGolfersDbContext context) : ControllerBase
    {
        private readonly BogeyGolfersDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return _context.Roles;
        }
    }
}