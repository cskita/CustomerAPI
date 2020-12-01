using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Interface.Repository.City;
using CustomerAPI.Framework.GeneralException;
using CityModel = CustomerAPI.Core.Model.City.City;

namespace CustomerAPI.Infra.Data.Repository.City
{
    public class CityRepository : ICityRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<CityModel> GetQuery()
        {
            return _unitOfWork.Query<CityModel>();
        }

        public List<CityModel> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public List<CityModel> GetWithRegion()
        {
            return GetQuery()
                .Include(r => r.Region).AsNoTracking().ToList();
        }

        public CityModel GetById(int id)
        {
            var city = GetQuery()
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (city == null)
                throw new NotFoundException("City not found");

            return city;
        }

        public CityModel GetByIdWithRegion(int id)
        {
            var city = GetQuery()
                .Include(r => r.Region)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (city == null)
                throw new NotFoundException("City not found");

            return city;
        }
    }
}
