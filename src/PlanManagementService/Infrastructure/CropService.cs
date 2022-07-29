using PlanManagementService.Model;

namespace PlanManagementService.Infrastructure;

public interface ICropService
{
    Task<Crop> GetCropByIdAsync(long id, CancellationToken cancellationToken);
}

public class CropService : ICropService
{
    private readonly HttpClient _httpClient;

    public CropService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Crop> GetCropByIdAsync(long id, CancellationToken cancellationToken)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Crop>("crop/" + id, cancellationToken);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}