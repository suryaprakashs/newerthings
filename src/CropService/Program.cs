using CropService.Infrastructure;
using CropService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<RedisService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = builder.Configuration.GetValue<string>("redis:name");
    options.Configuration = builder.Configuration.GetValue<string>("redis:host") + ":" + builder.Configuration.GetValue<string>("redis:port");
});

var app = builder.Build();

await SeedCrops(app);

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


async Task SeedCrops(WebApplication application)
{
    var response = new List<Crop>();

    response.Add(new Crop{ Id = 1, Name = "Corn" });
    response.Add(new Crop{ Id = 2, Name = "Tomato" });

    var redisService = application.Services.GetRequiredService<RedisService>();
    await redisService.SetAsync("AllCrops", response, default);
}