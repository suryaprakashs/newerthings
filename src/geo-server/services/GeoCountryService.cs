using System;
using System.Threading.Tasks;
using Grpc.Core;
using Geo;
using geo_server.Redis;

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
            var response = new CountryResponse();

            var countries = _redisService.Get<IEnumerable<Country>>("AllCountries");
            foreach (var item in countries)
            {
                response.Countries.Add(new Country { Id = item.Id, Name = item.Name });
            }

            return response;
        }
    }
}