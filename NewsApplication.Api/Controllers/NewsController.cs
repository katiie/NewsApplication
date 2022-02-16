using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NewsApplication.Services.Interface;
using System.Threading.Tasks;

namespace NewsApplication.Api.Controllers
{
    [ApiController]
    [Route("News")]
    public class NewsController : ControllerBase
    {
        private string NewsUrl { get; set; }
        public NewsController(INewsAPI NewsAPI, IConfiguration configuration)
        {
            NewsUrl = $"{configuration.GetValue<string>("NewsApiUrl")}?apiKey={configuration.GetValue<string>("NewsApiKey")}";
            _NewsAPI = NewsAPI;
        }

        public INewsAPI _NewsAPI { get; }

        [HttpGet]

        public async Task<IActionResult> Get(int Page)
        {
            return Ok(await _NewsAPI.CallNewsApi(Page, NewsUrl));
        }


    }
}
