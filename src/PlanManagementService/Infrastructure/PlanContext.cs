using Microsoft.EntityFrameworkCore;
using PlanManagementService.Model;

namespace PlanManagementService.Infrastructure;

public class PlanContext : DbContext
{
    public PlanContext(DbContextOptions<PlanContext> options)
       : base(options) { }

    public DbSet<Plan> Plans { get; set; }

    public DbSet<Activity> Activities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseCosmos(
           "https://localhost:8081",
           "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
           databaseName: "PlanManagementDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plan>().OwnsMany(p => p.Activities);
    }
}