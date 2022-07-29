using System.ComponentModel.DataAnnotations.Schema;

namespace PlanManagementService.Model;

public record Plan
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }
    public long CropId { get; set; }
    public List<Activity> Activities { get; set; }
}

public record Activity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long PlanId { get; set; }
    public string Name { get; set; }
    public int Day { get; set; }
}