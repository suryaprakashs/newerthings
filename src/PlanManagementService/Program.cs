using Microsoft.EntityFrameworkCore;
using PlanManagementService.Model;
using PlanManagementService.Infrastructure;
using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDaprClient();
builder.Services.AddDbContext<PlanContext>();

builder.Services.AddScoped<IPlanRepository, PlanRepository>();

builder.Services.AddSingleton<ICropService, CropService>(
            _ => new CropService(DaprClient.CreateInvokeHttpClient("cropservice")));

var app = builder.Build();

SeedPlans(app);

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


void SeedPlans(WebApplication app)
{
    using IServiceScope? scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<PlanContext>();

    ArgumentNullException.ThrowIfNull(context);
    context.Database.EnsureDeletedAsync().Wait();
    context.Database.EnsureCreatedAsync().Wait();

    var cornPlan = new Plan
    {
        Id = 1,
        Name = "Standard Corn Sowing",
        CropId = 1,
        Activities = new List<Activity>
        {
            new Activity { Id = 1, Day = 1, Name = "Sowing" },
            new Activity { Id = 2, Day = 110, Name = "Harvesting" }
        }
    };

    context.Add(cornPlan);
    context.SaveChanges();
}