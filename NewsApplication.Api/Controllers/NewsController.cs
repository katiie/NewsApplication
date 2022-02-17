using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NewsApplication.Services.Interface;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsApplication.Api.Controllers
{
    [ApiController]
    [Route("News")]
    public class NewsController : ControllerBase
    {
        private string NewsUrl { get; set; }
        public INewsAPI _NewsAPI { get; }

        static HttpClient client;
        public NewsController(IConfiguration configuration, INewsAPI newsAPI )
        {
            ConstructUrl(configuration);
            client = new HttpClient();
            _NewsAPI = newsAPI;
        }

        private void ConstructUrl(IConfiguration configuration)
        {
            NewsUrl = $"{configuration.GetValue<string>("NewsApiUrl")}";
        }

        [HttpGet]

        public async Task<IActionResult> Get(int Page)
        {
            return Ok(await _NewsAPI.CallThirdPartyNewsApi(Page, NewsUrl));
        }


    }
}
