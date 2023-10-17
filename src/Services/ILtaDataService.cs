using RestSharp;
using System.Text.Json.Nodes;

namespace TsbSia.LtaDataMallApi.Services
{
    public interface ILtaDataService
    {
        Task<RestResponse<JsonNode>> GetBusArrivalInfoAsync(string busStopCode, string? serviceNo = null, CancellationToken cancellationToken = default);
        Task<RestResponse<JsonNode>> GetBusStopsAsync(CancellationToken cancellationToken = default);

    }
}
