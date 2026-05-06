using BogeyGolfersWeb.models;
using Microsoft.EntityFrameworkCore;
namespace BogeyGolfersWeb.Context
{
    public class BogeyGolfersDbContext(DbContextOptions<BogeyGolfersDbContext> options) : DbContext(options)
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}