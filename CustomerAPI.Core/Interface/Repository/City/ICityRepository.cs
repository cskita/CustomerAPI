using System.Collections.Generic;
using CityModel = CustomerAPI.Core.Model.City;

namespace CustomerAPI.Core.Interface.Repository.City
{
    public interface ICityRepository
    {
        List<CityModel.City> Get();
        List<CityModel.City> GetWithRegion();
        CityModel.City GetById(int id);
        CityModel.City GetByIdWithRegion(int id);
    }
}
