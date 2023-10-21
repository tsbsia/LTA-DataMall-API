using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using TsbSia.LtaDataMallApi.Services;

namespace TsbSia.LtaDataMallApi.Controllers
{
    public class BusController : BaseController
    {
        public BusController(ILogger<BusController> logger, ILtaDataService ltaDataService, IConfiguration configuration)
           : base(logger, ltaDataService, configuration)
        {
        }

        [HttpGet("Arrival")]
        public async Task<JsonNode?> GetBusArrivalInfoAsync(string busStopCode, string? serviceNo = null)
        {
            var response = await LtaDataService.GetBusArrivalInfoAsync(busStopCode, serviceNo);
            return Return(response!);
        }

        [HttpGet("Stops")]
        public async Task<JsonNode?> GetBusStopsAsync()
        {
            var response = await LtaDataService.GetBusStopsAsync();
            return Return(response!);
        }

        [HttpGet("Services")]
        public async Task<JsonNode?> GetBusServicesAsync()
        {
            var response = await LtaDataService.GetBusServicesAsync();
            return Return(response!);
        }
    }
}
