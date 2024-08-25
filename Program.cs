using System.Reflection;
using KlassyCafePostgreSql.DAL.Context;
using KlassyCafePostgreSql.Hubs;
using KlassyCafePostgreSql.Services.AboutServices;
using KlassyCafePostgreSql.Services.BannerServices;
using KlassyCafePostgreSql.Services.CategoryServices;
using KlassyCafePostgreSql.Services.MenuServices;
using KlassyCafePostgreSql.Services.ProductServices;
using KlassyCafePostgreSql.Services.ReservationServices;
using KlassyCafePostgreSql.Services.TableServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    builder.Services.AddSignalR();

    builder.Services.AddDbContext<Context>();

    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

    builder.Services.AddScoped<IAboutService, AboutService>();
    builder.Services.AddScoped<IBannerService, BannerService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IMenuService, MenuService>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IReservationService, ReservationService>();
    builder.Services.AddScoped<ITableService, TableService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapHub<SignalRHub>("/signalrhub");

app.Run();
