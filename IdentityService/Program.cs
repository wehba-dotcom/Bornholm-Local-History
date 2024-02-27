using IdentityApi.Data;
using IdentityApi.Models;
using IdentityApi.Service.IService;
using IdentityApi.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using IdentityApi.Infrastructure;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
string ConnectionString = "host=cow-01.rmq2.cloudamqp.com;virtualHost=vohieqyo;username=vohieqyo;password=hRtXREuzSQwNnU085CF8r_3DCKXhsQZv";
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddScoped<IRepositoryAppUser<IdentityApi.Models.ApplicationUser>, RepositoryAppUser>();

builder.Services.AddIdentity<IdentityApi.Models.ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
Task.Factory.StartNew(() =>
    new MessageListener(app.Services, ConnectionString).Start());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseHttpMetrics();
app.MapMetrics();
app.Run();
