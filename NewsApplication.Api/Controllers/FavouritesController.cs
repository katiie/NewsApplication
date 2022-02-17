using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApplication.Core;
using NewsApplication.Infrastructure.IRepository;
using NewsApplication.Services.ViewModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace NewsApplication.Api.Controllers
{
    [ApiController]
    [Route("FavouriteNews")]
    public class FavouritesController : ControllerBase
    {
        private new string Url { get; }
        static HttpClient client;
        public FavouritesController(IFavouriteRepo IFavouriteNewsRepo)
        {
            client = new HttpClient();
            this._IFavouriteNewsRepo = IFavouriteNewsRepo;
        }
        public IFavouriteRepo _IFavouriteNewsRepo { get; }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {

            var response = _IFavouriteNewsRepo.Get(Id);
            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _IFavouriteNewsRepo.GetFavouriteNews();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(NewsDataViewModel Payload)
        {
            var serializedData = JsonSerializer.Serialize(Payload);
            var response = _IFavouriteNewsRepo.Add(JsonSerializer.Deserialize<Favourite>(serializedData));

            if (response == default)
            {
                return BadRequest(Payload);
            }

            return NoContent();
        }
    }
}
