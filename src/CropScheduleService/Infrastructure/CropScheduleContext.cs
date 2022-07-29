using CropScheduleService.Models;
using Microsoft.EntityFrameworkCore;

namespace CropScheduleService.Infrastructure;

public class CropScheduleContext : DbContext
{
     public CropScheduleContext(DbContextOptions<CropScheduleContext> options)
        : base(options) { }

    public DbSet<CropSchedule> CropSchedules { get; set; }
}
