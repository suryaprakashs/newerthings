using Microsoft.EntityFrameworkCore;
using PlanManagementService.Model;

namespace PlanManagementService.Infrastructure;

public class PlanContext : DbContext
{
     public PlanContext(DbContextOptions<PlanContext> options)
        : base(options) { }

    public DbSet<Plan> Plans { get; set; }

    public DbSet<Activity> Activities { get; set; }
}