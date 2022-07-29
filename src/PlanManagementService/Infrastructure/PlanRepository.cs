using Microsoft.EntityFrameworkCore;
using PlanManagementService.Model;

namespace PlanManagementService.Infrastructure;

public class PlanRepository : IPlanRepository
{
    private readonly PlanContext _context;

    public PlanRepository(PlanContext context)
    {
        this._context = context;
    }

    public async Task<Plan> CreateAsync(Plan plan, CancellationToken cancellationToken)
    {
        await _context.Plans.AddAsync(plan, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return plan;
    }

    public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Plans.ToListAsync(cancellationToken);
    }

    public async Task<Plan> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await _context.Plans
            .Include(x => x.Activities)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}