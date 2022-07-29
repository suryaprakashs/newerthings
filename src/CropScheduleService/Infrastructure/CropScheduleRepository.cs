using CropScheduleService.Models;
using Microsoft.EntityFrameworkCore;

namespace CropScheduleService.Infrastructure;

public class CropScheduleRepository : ICropScheduleRepository
{
    private readonly CropScheduleContext _context;

    public CropScheduleRepository(CropScheduleContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<CropSchedule>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.CropSchedules.ToListAsync(cancellationToken);
    }

    public async Task<CropSchedule> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await _context.CropSchedules.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
