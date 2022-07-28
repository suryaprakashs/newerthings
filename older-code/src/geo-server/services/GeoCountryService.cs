using geo_server.Redis;
using Geo;
using Grpc.Core;

namespace geo_server.Services
{
    public class GeoCountryService : GeoServices.GeoServicesBase
    {
        private readonly RedisService _redisService;

        public GeoCountryService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public override async Task<CountryResponse> GetCountries(CountryRequest request, ServerCallContext context)
        {
            await Task.CompletedTask;

            var countries = _redisService.Get<IEnumerable<Country>>("AllCountries");

            var response = new CountryResponse();
            foreach (var item in countries)
            {
                response.Countries.Add(new Country { Id = item.Id, Name = item.Name });
            }

            return response;
        }
    }
}