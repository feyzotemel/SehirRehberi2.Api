using SehirRehberi2.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi2.Api.Data
{
    public interface IAppRepository
    {
        void Add<T>(T Entity) where T:class;
        void Delete<T>(T Entity) where T : class;
        bool SaveAll();

        List<City> GetCities();
        List<Photo> GetPhotosByCityId(int id);
        City GetCityById( int cityId);
        Photo GetPhoto(int id);


    }
}
