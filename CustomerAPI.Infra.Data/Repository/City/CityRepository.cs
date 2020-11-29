using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CityModel = CustomerAPI.Core.Model.City;
using CustomerAPI.Core.Interface.Repository.City;
using CustomerAPI.Framework.GeneralException;

namespace CustomerAPI.Infra.Data.Repository.City
{
    public class CityRepository : ICityRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<CityModel.City> GetQuery()
        {
            return _unitOfWork.Query<CityModel.City>();
        }

        public List<CityModel.City> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public List<CityModel.City> GetWithRegion()
        {
            return GetQuery()
                .Include(r => r.Region).AsNoTracking().ToList();
        }

        public CityModel.City GetById(int id)
        {
            var city = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (city == null)
                throw new NotFoundException("City is not found");

            return city;
        }

        public CityModel.City GetByIdWithRegion(int id)
        {
            var city = GetQuery()
                .Include(r => r.Region).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (city == null)
                throw new NotFoundException("City is not found");

            return city;
        }
    }
}
