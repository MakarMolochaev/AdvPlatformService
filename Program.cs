using AdvPlatformService.Data;
using AdvPlatformsService.Abstract;
using AdvPlatformsService.Controller;
using AdvPlatformsService.Data;
using AdvPlatformsService.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdvPlatformService API", Version = "v1" });
});

services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("AdvPlatformService"));
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddScoped<IPlatformsService, PlatformsService>();
services.AddScoped<IPlatformsRepository, PlatformsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

app.MapPlatformsEndpoints();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();