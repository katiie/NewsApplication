using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NewsApplication.APP.Services;
using NewsApplication.Services.Interface;
using NewsApplication.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsApplication.App.Controllers
{
    public class NewsController : Controller
    {
        private readonly IAPIServices _APIservices;

        private Dictionary<string, string> NewsUrl { get; set; }
        public NewsController(ILogger<NewsController> Logger, IConfiguration configuration, IAPIServices services)
        {
            _Logger = Logger;
            this._APIservices = services;
            NewsUrl = configuration.GetSection("NewsApi").Get<Dictionary<string, string>>();
        }

        public ILogger<NewsController> _Logger { get; }

        // GET: NewsController
        public async Task<ActionResult> Index(int? Page)
        {
            try
            {
                if (!Page.HasValue)
                {
                    Page = 1;
                }
                NewsUrl.TryGetValue("AddFavourites", out string AddFavourites);
                ViewBag.PostFav = AddFavourites;
                NewsUrl.TryGetValue("GetNews", out string Url);
                Url = $"{Url}?page={Page}";

                var data = await _APIservices.RetrieveData(Url);

                if (string.IsNullOrEmpty(data))
                    return View();
                var newsObject = JsonSerializer.Deserialize<Dictionary<string, object>>(data);
                newsObject.TryGetValue("results", out object newsStream);
                var news = JsonSerializer.Deserialize<List<ThirdPartyNewsDataViewModel>>(newsStream.ToString());
                return View(news);
            }
            catch (Exception er)
            {
                _Logger.LogError(er.Message);
                return View();
            }
        }

        public async Task<ActionResult> Favourites()
        {
            try
            {
                NewsUrl.TryGetValue("GetFavourites", out string Url);
                var data = await _APIservices.RetrieveData(Url);

                if (string.IsNullOrEmpty(data))
                    return View();
                var newsObject = JsonSerializer.Deserialize<Dictionary<string, object>>(data);
                newsObject.TryGetValue("$values", out object newsStream);
                var newsList = JsonSerializer.Deserialize<List<NewsDataViewModel>>(newsStream.ToString());
                return View(newsList);
            }
            catch (Exception er)
            {
                _Logger.LogError(er.Message);
                return View();
            }
        }


    }
}
