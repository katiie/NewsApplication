using Microsoft.Extensions.Logging;
using NewsApplication.Core;
using NewsApplication.Infrastructure.IRepository;
using System;
using System.Collections.Generic;

namespace NewsApplication.Infrastructure.Repository
{
    public class FavouriteRepo : IFavouriteRepo
    {
        public FavouriteRepo(ApplicationDbContext context, ILogger<FavouriteRepo> logger)
        {

            _Context = context;
            _Logger = logger;
        }

        public ApplicationDbContext _Context { get; }
        public ILogger<FavouriteRepo> _Logger { get; }

        public Favourite Add(Favourite model)
        {
            try
            {
                _Context.Favourites.Add(model);
                _Context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
                _Logger.LogError("Message :{0} ", ex.Message);
                return default;
            }
        }

        public Favourite Get(int Id)
        {
            try
            {
                return _Context.Favourites.Find(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
                _Logger.LogError("Message :{0} ", ex.Message);
                return default;
            }
        }

        public IEnumerable<Favourite> GetFavouriteNews()
        {
            try
            {
                return _Context.Favourites;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
                _Logger.LogError("Message :{0} ", ex.Message);
                return default;
            }
        }
    }
}
