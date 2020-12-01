using System.Collections.Generic;
using CityModel = CustomerAPI.Core.Model.City.City;

namespace CustomerAPI.Core.Interface.Repository.City
{
    public interface ICityRepository
    {
        List<CityModel> Get();
        List<CityModel> GetWithRegion();
        CityModel GetById(int id);
        CityModel GetByIdWithRegion(int id);
    }
}
