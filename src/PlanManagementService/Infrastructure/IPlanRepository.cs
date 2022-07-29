using Microsoft.AspNetCore.Mvc;
using PlanManagementService.Model;

namespace PlanManagementService.Infrastructure;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> GetAllAsync(CancellationToken cancellationToken);
    Task<Plan> GetByIdAsync(long id, CancellationToken cancellationToken);
    Task<Plan> CreateAsync(Plan plan, CancellationToken cancellationToken);
}
