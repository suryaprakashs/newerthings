using System.ComponentModel.DataAnnotations.Schema;

namespace CropScheduleService.Models;

public class CropSchedule
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }
    public long CropId { get; set; }
    public long PlanId { get; set; }
    public DateTime ScheduleDate { get; set; }
}
