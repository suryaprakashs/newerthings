using CropScheduleService.Infrastructure;
using CropScheduleService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CropScheduleService.Controllers;

[ApiController]
[Route("[controller]")]
public class CropScheduleController : ControllerBase
{
    private readonly ICropScheduleRepository _cropScheduleRepository;
    private readonly ILogger<CropScheduleController> _logger;

    public CropScheduleController(
        ICropScheduleRepository cropScheduleRepository,
        ILogger<CropScheduleController> logger)
    {
        _cropScheduleRepository = cropScheduleRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<CropSchedule>> GetAsync(CancellationToken cancellationToken)
    {
        return await _cropScheduleRepository.GetAllAsync(cancellationToken);
    }

    
    [HttpGet("{id}")]
    public async Task<CropSchedule> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return await _cropScheduleRepository.GetByIdAsync(id, cancellationToken);
    }
}
