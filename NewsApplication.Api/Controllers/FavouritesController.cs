using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsApplication.Core;
using NewsApplication.Infrastructure.IRepository;
using NewsApplication.Services.ViewModel;
using System.Linq;
using System.Text.Json;

namespace NewsApplication.Api.Controllers
{
    [ApiController]
    [Route("FavouriteNews")]
    public class FavouritesController : ControllerBase
    {
        private new string Url { get; }
        public FavouritesController(IFavouriteRepo IFavouriteNewsRepo)
        {
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
            if (response != null && response.Any())
            {
                return Ok(response);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(NewsDataViewModel News)
        {
            var response = _IFavouriteNewsRepo.Add(new Favourite { News = JsonSerializer.Serialize(News) });

            if (response == default)
            {
                return BadRequest(News);
            }

            return NoContent();
        }
    }
}
