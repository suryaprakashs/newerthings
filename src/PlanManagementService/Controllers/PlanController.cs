using Microsoft.AspNetCore.Mvc;
using Dapr.Client;
using PlanManagementService.Infrastructure;
using PlanManagementService.Model;

namespace PlanManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class PlanController : ControllerBase
{
    private readonly IPlanRepository _planRepository;
    private readonly ICropService _cropService;
    private readonly ILogger<PlanController> _logger;

    public PlanController(
        IPlanRepository planRepository,
        ICropService cropService,
        ILogger<PlanController> logger)
    {
        _planRepository = planRepository;
        _cropService = cropService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Plan>> GetAsync(CancellationToken cancellationToken)
    {
        return await _planRepository.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<Plan> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await _planRepository.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Plan>> CreateAsync([FromBody]Plan plan, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(plan);

        var crop = await _cropService.GetCropByIdAsync(plan.CropId, cancellationToken);

        if (crop is null)
        {
            return BadRequest("Invalid Crop Id.");
        }

        var result = await _planRepository.CreateAsync(plan, cancellationToken);

        return Ok(result);
    }
}
