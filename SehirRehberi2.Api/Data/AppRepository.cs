using Microsoft.EntityFrameworkCore;
using SehirRehberi2.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi2.Api.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public List<City> GetCities()
        {
            var cities = _context.Cities.Include(c => c.Photos).ToList();
            return cities;
        }

        public City GetCityById(int cityId)
        {
            var citiy = _context.Cities.Include(c => c.Photos).FirstOrDefault(x => x.Id == cityId);
            return citiy;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.FirstOrDefault(x => x.Id == id);
            return photo;
        }

        public List<Photo> GetPhotosByCityId(int cityId)
        {
            var photos = _context.Photos.Where(p => p.CityId == cityId).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            var data = _context.SaveChanges();
            return data > 0;
        }
    }
}
