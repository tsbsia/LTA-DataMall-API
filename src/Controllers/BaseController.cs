using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using TsbSia.LtaDataMallApi.Services;

namespace TsbSia.LtaDataMallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> Logger;
        protected readonly ILtaDataService LtaDataService;
        protected readonly IConfiguration Configuration;

        public BaseController(ILogger<BaseController> logger, ILtaDataService ltaDataService, IConfiguration configuration)
        {
            Logger = logger;
            LtaDataService = ltaDataService;
            Configuration = configuration;
        }

        protected T? Return<T>(RestResponse<T?> response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Response.StatusCode = (int)response.StatusCode;
            }
            return response.Data;
        }
    }
}
