using ProductApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NuGet.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProductApi.Extensions;
using AutoMapper;
using ProductApi.Models;
using ProductApi.Infrastructure;
using ProductApi.Models.Dto;
using ProductApi;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string ConnectionString = "host=cow-01.rmq2.cloudamqp.com;virtualHost=vohieqyo;username=vohieqyo;password=hRtXREuzSQwNnU085CF8r_3DCKXhsQZv";


try
{
    var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
catch (Exception ex)
{
    // Handle the exception here, such as logging or displaying an error message
    Console.WriteLine("An error occurred while setting up the DbContext:");
    Console.WriteLine(ex.Message);
}


// Register repositories for dependency injection
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
//builder.Services.AddSingleton<IConverter<Product, ProductDto>, ProductConverter>();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id=JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{}
        }
    });
});



builder.AddAppAuthetication();

builder.Services.AddAuthorization();

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
