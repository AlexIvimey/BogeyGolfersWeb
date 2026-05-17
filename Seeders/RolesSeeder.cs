using BogeyGolfersWeb.Context;
using BogeyGolfersWeb.models;

namespace BogeyGolfersWeb.Seeders
{
    public class RolesSeeder()
    {
        public static async Task SeedRolesAsync(BogeyGolfersDbContext context)
        {
            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new Role
                {
                    Title = "Administrator"
                });
                await context.Roles.AddAsync(new Role
                {
                    Title = "Member"
                });
                await context.SaveChangesAsync();
            }
        }
    }
}