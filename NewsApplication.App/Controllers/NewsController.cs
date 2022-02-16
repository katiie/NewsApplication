using Microsoft.AspNetCore.Mvc;
using NewsApplication.Services.Interface;
using NewsApplication.Services.ViewModel;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsApplication.App.Controllers
{
    public class NewsController : Controller
    {
        private string NewsUrl { get; set; }
        public NewsController(INewsAPI NewsAPI)
        {
            _NewsAPI = NewsAPI;
        }

        public INewsAPI _NewsAPI { get; }

        // GET: NewsController
        public async Task<ActionResult> Index()
        {
            var data = await _NewsAPI.CallNewsApi(1, NewsUrl);
            if (string.IsNullOrEmpty(data))
                return View();
            var news = JsonSerializer.Deserialize<List<NewsDataViewModel>>(data);
            return View(news);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
