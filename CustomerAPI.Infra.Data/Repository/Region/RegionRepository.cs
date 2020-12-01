using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Infra.Data.Context;
using CustomerAPI.Core.Interface.Repository.Region;
using CustomerAPI.Framework.GeneralException;
using RegionModel = CustomerAPI.Core.Model.Region.Region;

namespace CustomerAPI.Infra.Data.Repository.Region
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegionRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IQueryable<RegionModel> GetQuery()
        {
            return _unitOfWork.Query<RegionModel>();
        }

        public List<RegionModel> Get()
        {
            return GetQuery().AsNoTracking().ToList();
        }

        public RegionModel GetById(int id)
        {
            var region = GetQuery().AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (region == null)
                throw new NotFoundException("Region is not found");

            return region;
        }
    }
}
