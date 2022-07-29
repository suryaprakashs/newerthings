using Microsoft.AspNetCore.Mvc;
using CropService.Infrastructure;
using CropService.Models;

namespace CropService.Controllers;

[ApiController]
[Route("[controller]")]
public class CropController : ControllerBase
{
    private readonly RedisService _redisService;
    private readonly ILogger<CropController> _logger;

    public CropController(
        RedisService redisService,
        ILogger<CropController> logger)
    {
        _redisService = redisService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Crop>> GetAsync(CancellationToken cancellationToken)
    {
        return await _redisService.GetAsync<IEnumerable<Crop>>("AllCrops", cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Crop>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var crops = await _redisService.GetAsync<IEnumerable<Crop>>("AllCrops", cancellationToken);

        var crop = crops.SingleOrDefault(x => x.Id == id);

        if (crop is default(Crop))
        {
            return new NotFoundResult();
        }

        return crop;
    }
}
