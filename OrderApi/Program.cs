using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderApi.CouponAPI;
using OrderApi.Data;
using OrderApi.Extensions;
using OrderApi.Infrastructure;
using OrderApi.Models;
using SharedModels;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


string ConnectionString = "host=cow-01.rmq2.cloudamqp.com;virtualHost=vohieqyo;username=vohieqyo;password=hRtXREuzSQwNnU085CF8r_3DCKXhsQZv";

// Add services to the container.

string productServiceBaseUrl = "http://localhost:8000/api/product/";
string customerServiceBaseUrl = "http://localhost:8001/api/auth/";

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

try
{
    var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
    builder.Services.AddDbContext<OrderApiContext>(options =>
        options.UseSqlServer(connectionString));
}
catch (Exception ex)
{
    // Handle the exception here, such as logging or displaying an error message
    Console.WriteLine("An error occurred while setting up the DbContext:");
    Console.WriteLine(ex.Message);
}

// Register repositories for dependency injection
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();


// Register product service gateway for dependency injection
builder.Services.AddSingleton<IServiceGateway<ProductDto>>(new
    ProductServiceGateway(productServiceBaseUrl));

// Register product service gateway for dependency injection
builder.Services.AddSingleton<IServiceGateway<ApplicationUser>>(new
    CustomerServiceGateway(customerServiceBaseUrl));


// Register MessagePublisher (a messaging gateway) for dependency injection
builder.Services.AddSingleton<IMessagePublisher>(new
    MessagePublisher(ConnectionString));

// Register OrderConverter for dependency injection
builder.Services.AddSingleton<IConverter<Order, OrderDto>, OrderConverter>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
