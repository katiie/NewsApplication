using NewsApplication.Core;
using System.Collections.Generic;

namespace NewsApplication.Infrastructure.IRepository
{
    public interface IFavouriteRepo
    {

        Favourite Add(Favourite model);
        Favourite Get(int Id);
        IEnumerable<Favourite> GetFavouriteNews();
    }
}