using System;
using System.Threading.Tasks;
using Grpc.Core;
using Geo;

namespace geo_server.Services
{
    public class GeoCountryService : GeoServices.GeoServicesBase
    {
        public override async Task<CountryResponse> GetCountries(CountryRequest request, ServerCallContext context)
        {
            var response =  new CountryResponse();
            response.Countries.Add(new Country { Id = 1, Name = "India" });
            return response;
        }
    }
}