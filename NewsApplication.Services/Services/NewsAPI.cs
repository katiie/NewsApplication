using NewsApplication.Infrastructure.IRepository;
using NewsApplication.Services.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsApplication.Services
{
    public class NewsAPI : INewsAPI
    {
        static HttpClient client;
        public NewsAPI(IFavouriteRepo IFavouriteNewsRepo)
        {
            client = new HttpClient();
            this._IFavouriteNewsRepo = IFavouriteNewsRepo;
        }

        public IFavouriteRepo _IFavouriteNewsRepo { get; }

        public async Task<string> CallNewsApi(int Page, string Url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{Url}&page={Page}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return default;
            }
        }

    }
}
