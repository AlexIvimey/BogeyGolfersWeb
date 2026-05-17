using BogeyGolfersWeb.Context;
using BogeyGolfersWeb.models;
using Microsoft.EntityFrameworkCore;

namespace BogeyGolfersWeb.Seeders
{
    public class UserSeeder()
    {
        public static async Task SeedUserAsync(BogeyGolfersDbContext context)
        {
            if (!context.Users.Any())
            {
                var adminRoleId = await context.Roles.Where(u => u.Title == "Administrator").Select(u => u.Id).SingleAsync();
                await context.Users.AddAsync(new User
                {
                    RoleId = adminRoleId,
                    Username = "Shebs"
                });
                await context.SaveChangesAsync();
            }
        }
    }
}