using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlite("Data Source=c:\\temp\\animals.db"));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IModifyAnimal, AnimalRepo>();
builder.Services.AddTransient<IPresentData, AnimalRepo>();
var app = builder.Build();

app.UseStaticFiles();
//using (var scope = app.Services.CreateScope())
//{
//    var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
//    ctx.Database.EnsureDeleted();
//    ctx.Database.EnsureCreated();
//}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});
app.Run();