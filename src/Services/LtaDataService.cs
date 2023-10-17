using Microsoft.Extensions.Options;
using RestSharp;
using System.Text.Json.Nodes;
using TsbSia.LtaDataMallApi.Options;
using TsbSia.LtaDataMallApi.Utils;

namespace TsbSia.LtaDataMallApi.Services
{
    public class LtaDataService : ILtaDataService
    {
        private readonly RestClient _client;
        private readonly LtaDataServiceOptions _options;
        private readonly ILogger<LtaDataService> _logger;

        private const string serviceName = "LTA Data Service";
        public LtaDataService(IOptions<LtaDataServiceOptions> options, ILogger<LtaDataService> logger)
        {
            _options = options.Value;
            _logger = logger;
            var _clientOptions = new RestClientOptions(_options.BaseUrl)
            {
                Authenticator = new AccountKeyAuthenticator(_options.AccountKey),
                ThrowOnAnyError = true
            };

            _client = new RestClient(_clientOptions);

        }
        private async Task<RestResponse<T>> QueryAsync<T>(Func<RestClient, Task<RestResponse<T>>> func)
        {
            try
            {
                return await func(_client);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: {service}\n{error}", serviceName, ex.ToString());
                RestResponse<T> d = new RestResponse<T>(new RestRequest())
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                };
                return d;
            }
        }
        public async Task<RestResponse<JsonNode>> GetBusArrivalInfoAsync(string busStopCode, string? serviceNo = null, CancellationToken cancellationToken = default)
        {
            var request = new RestRequest($"/BusArrivalv2");
            request.AddParameter("BusStopCode", busStopCode);
            if (!string.IsNullOrWhiteSpace(serviceNo))
            {
                request.AddParameter("ServiceNo", serviceNo);
            }
            var response = await QueryAsync(async client =>
            {
                _logger.LogInformation("{service} GetBusArrivalInfoAsync. Url: {Resource}", serviceName, client.BuildUri(request));

                return await client.ExecuteGetAsync<JsonNode>(request, cancellationToken);
            });
            return response;
        }

        public async Task<RestResponse<JsonNode>> GetBusStopsAsync(CancellationToken cancellationToken = default)
        {
            var request = new RestRequest($"/BusStops");

            var response = await QueryAsync(async client =>
            {
                _logger.LogInformation("{service} GetBusStopsAsync. Url: {Resource}", serviceName, client.BuildUri(request));

                return await client.ExecuteGetAsync<JsonNode>(request, cancellationToken);
            });
            return response;
        }
    }
}
