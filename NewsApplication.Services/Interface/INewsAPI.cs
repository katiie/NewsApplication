using System.Threading.Tasks;

namespace NewsApplication.Services.Interface
{
    public interface INewsAPI
    {
        Task<string> CallNewsApi(int page, string Url);
    }
}
