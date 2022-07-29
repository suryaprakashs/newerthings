using CropScheduleService.Infrastructure;
using CropScheduleService.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CropScheduleContext>(
    options => options.UseInMemoryDatabase(databaseName: "Farming"));

builder.Services.AddScoped<ICropScheduleRepository, CropScheduleRepository>();

var app = builder.Build();

SeedCropSchedule(app);

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

void SeedCropSchedule(WebApplication app)
{
    using IServiceScope? scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<CropScheduleContext>();

    ArgumentNullException.ThrowIfNull(context);

    var cropSchedule = new CropSchedule
    {
        Name = "Summer Tomato Schedule",
        CropId = 1,
        PlanId = 1,
        ScheduleDate = DateTime.Now
    };

    context.Add(cropSchedule);
    context.SaveChanges();
}
