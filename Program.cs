using BogeyGolfersWeb.Context;
using BogeyGolfersWeb.models;
using BogeyGolfersWeb.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration.GetConnectionString("BogeyGolfersDb");
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Data", connString);
Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
builder.Services.AddDbContext<BogeyGolfersDbContext>(options =>
{
    options.UseSqlite($"Data Source={dbPath}");
});
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Seed startup data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BogeyGolfersDbContext>();

    await db.Database.MigrateAsync();
    await RolesSeeder.SeedRolesAsync(db);
    await UserSeeder.SeedUserAsync(db);
}

app.Run();
