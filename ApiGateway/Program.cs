using ApiGateway.Extensions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.AddAppAuthetication();
//if (builder.Environment.EnvironmentName.ToString().ToLower().Equals("production"))
//{
//    builder.Configuration.AddJsonFile("ocelot.Production.json", optional: false, reloadOnChange: true);
//}
//else
//{
//    builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);




var app = builder.Build();
app.UseHttpMetrics();
app.MapMetrics();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapMetrics();
//});

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();
