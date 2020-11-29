using System.Collections.Generic;
using CustomerAPI.Framework.Domain;
using CityModel = CustomerAPI.Core.Model.City;

namespace CustomerAPI.Core.Interface.Service.City
{
    public interface ICityService
    {
        BaseResult<List<CityModel.City>> Get();
        BaseResult<List<CityModel.City>> GetWithRegion();

        BaseResult<CityModel.City> GetById(int id);
        BaseResult<CityModel.City> GetByIdWithRegion(int id);
    }
}
