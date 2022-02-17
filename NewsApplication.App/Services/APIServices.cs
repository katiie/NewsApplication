using NewsApplication.Services.ViewModel;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NewsApplication.APP.Services
{
    public interface IAPIServices
    {
        Task<string> RetrieveData(string Url);
        Task<string> SaveData(NewsDataViewModel Payload, string Url);
    }

    public class APIServices : IAPIServices
    {
        static HttpClient client;
        public APIServices()
        {
            client = new HttpClient();
        }
        public async Task<string> RetrieveData(string Url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{Url}");
                response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);
                    return responseBody;
                }
                else
                {
                    return default;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return default;
            }
        }

        public async Task<string> SaveData(NewsDataViewModel Payload, string Url)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(Url, Payload);
                response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    return responseBody;
                }
                else
                {
                    return default;
                }

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
