using NewsApplication.Services.ViewModel;
using System.Threading.Tasks;

namespace NewsApplication.Services.Interface
{
    public interface INewsAPI
    {
        Task<string> CallThirdPartyNewsApi(int page, string Url);
    }
}
