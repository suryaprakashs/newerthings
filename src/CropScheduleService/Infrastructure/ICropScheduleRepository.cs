using CropScheduleService.Models;

namespace CropScheduleService.Infrastructure;

public interface ICropScheduleRepository 
{
    Task<IEnumerable<CropSchedule>> GetAllAsync(CancellationToken cancellationToken);
    Task<CropSchedule> GetByIdAsync(long id, CancellationToken cancellationToken);
}