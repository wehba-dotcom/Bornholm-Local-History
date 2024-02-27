using WebApi.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApi.Service.IService;
using WebApi.Utility;
using Mango.Web.Service.IService;
using Prometheus;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IFeallesService, FeallesService>();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<IOrderService, OrderService>();



SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.FeallesAPIBase = builder.Configuration["ServiceUrls:Feallesbase"];
SD.ProductAPIBase = builder.Configuration["ServiceUrls:Product"];
SD.OrderAPIBase = builder.Configuration["ServiceUrls:Order"];
SD.GateWayIBase = builder.Configuration["ServiceUrls:ApigateWay"];

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://apigateway") });
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IFeallesService, FeallesService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllersWithViews();


//builder.Services.AddHttpClient("MyClient", client =>
//{
//    // Set the timeout to 30 seconds (or any other duration you prefer)
//    client.Timeout = TimeSpan.FromSeconds(30);
//});




builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

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
app.UseHttpMetrics();
app.MapMetrics();
app.Run();
