using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    var hostName = Environment.MachineName; // Get the Kubernetes host name
    await context.Response.WriteAsync($"Hello World! Running on host: {hostName}");
});

app.Run();