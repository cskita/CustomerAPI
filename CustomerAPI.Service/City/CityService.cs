using System;
using System.Collections.Generic;
using CustomerAPI.Framework.Domain;
using CityModel = CustomerAPI.Core.Model.City;
using CustomerAPI.Core.Interface.Service.City;
using CustomerAPI.Core.Interface.Repository.City;

namespace CustomerAPI.Service.City
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public BaseResult<List<CityModel.City>> Get()
        {
            try
            {
                var cities = _cityRepository.Get();

                return BaseResult<List<CityModel.City>>.OK(cities);
            }
            catch (Exception e)
            {
                return BaseResult<List<CityModel.City>>.NotOK(e.Message);
            }
        }

        public BaseResult<List<CityModel.City>> GetWithRegion()
        {
            try
            {
                var cities = _cityRepository.GetWithRegion();

                return BaseResult<List<CityModel.City>>.OK(cities);
            }
            catch (Exception e)
            {
                return BaseResult<List<CityModel.City>>.NotOK(e.Message);
            }
        }

        public BaseResult<CityModel.City> GetById(int id)
        {
            var city = _cityRepository.GetById(id);

            return BaseResult<CityModel.City>.OK(city);
        }

        public BaseResult<CityModel.City> GetByIdWithRegion(int id)
        {
            try
            {
                var city = _cityRepository.GetByIdWithRegion(id);

                return BaseResult<CityModel.City>.OK(city);
            }
            catch (Exception e)
            {
                return BaseResult<CityModel.City>.NotOK(e.Message);
            }
        }
    }
}
