using geo_server.Redis;
using geo_server.Services;
using Geo;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = builder.Configuration.GetValue<string>("redis:name");
    options.Configuration = builder.Configuration.GetValue<string>("redis:host") + ":" + builder.Configuration.GetValue<string>("redis:port");
});

builder.Services.AddSingleton<RedisService>();
builder.Services.AddSession();

builder.WebHost.ConfigureKestrel((context, options) =>
  {
      options.Listen(IPAddress.Any, 5129, listenOptions =>
      {
          listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
      });
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSession();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GeoCountryService>();
});

SeedData();

app.Run();


void SeedData()
{
    var response = new List<Country>();
    response.Add(new Country { Id = 1, Name = "India" });
    response.Add(new Country { Id = 2, Name = "Russia" });
    var redisService = app.Services.GetRequiredService<RedisService>();
    redisService.Set("AllCountries", response);
}